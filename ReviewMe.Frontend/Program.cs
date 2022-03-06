using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReviewMe.Frontend.Mocks.Services;
using ReviewMe.Frontend.Services;
using ReviewMe.Frontend.Services.Data;
using ReviewMe.Frontend.Services.Notification;
using System.Globalization;
using System.Net.Http.Headers;

namespace ReviewMe.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(_ => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiAddress"))
            });

            builder.Services.AddScoped<IHttpClientService, HttpClientService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddBlazoredLocalStorage();

            var useMockData = builder.Configuration.GetValue<bool>("useMockData");
            if (useMockData)
                builder.Services.AddMockDataServices();
            else
                builder.Services.AddDataServices();

            var host = builder.Build();
            var localStorage = host.Services.GetService<ILocalStorageService>();

            // The service won't be null because I've just added them 
            // ReSharper disable PossibleNullReferenceException

            // Get JWT from local storage
            if (localStorage == null)
            {
                throw new NullReferenceException(nameof(localStorage));
            }

            var token = await localStorage.GetItemAsync<string>("jwtToken");

            // Change the header in httpClient
            var httpClient = host.Services.GetService<HttpClient>();

            if (httpClient == null)
            {
                throw new NullReferenceException(nameof(httpClient));
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // ReSharper restore PossibleNullReferenceException

            if (CultureInfo.CurrentCulture.Name == "en-GB" && CultureInfo.CurrentCulture.Clone() is CultureInfo cultureInfo)
            {
                var dateTimeFormatInfo = cultureInfo.DateTimeFormat;
                dateTimeFormatInfo.ShortDatePattern = "dd/MM/yyyy";
                CultureInfo.CurrentCulture = cultureInfo;
            }

            await host.RunAsync();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
            => services.AddScoped<IEmployeesService, EmployeesService>()
                        .AddScoped<IAssessmentService, AssessmentService>()
                        .AddScoped<IReviewerTaskService, ReviewerTaskService>()
                        .AddScoped<IReviewersService, ReviewersService>()
                        .AddScoped<IReviewersFeedbackService, ReviewersFeedbackService>();


        public static IServiceCollection AddMockDataServices(this IServiceCollection services)
            => services.AddScoped<IEmployeesService, MockService>()
                .AddScoped<IAssessmentService, MockService>()
                .AddScoped<IReviewerTaskService, MockService>()
                .AddScoped<IReviewersService, MockService>()
                .AddScoped<IReviewersFeedbackService, MockService>();
    }
}
