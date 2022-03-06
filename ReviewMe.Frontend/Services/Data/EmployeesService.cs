using ReviewMe.Models.Employees;

namespace ReviewMe.Frontend.Services.Data
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IHttpClientService _httpClientService;

        public EmployeesService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<Employee>> Get()
            => await _httpClientService.GetJsonAsync<List<Employee>>("Employees") ?? new List<Employee>();

        public async Task<Employee> Get(int assessmentId)
            => await _httpClientService.GetJsonAsync<Employee>($"Employees/{assessmentId}") ?? new Employee();
    }
}