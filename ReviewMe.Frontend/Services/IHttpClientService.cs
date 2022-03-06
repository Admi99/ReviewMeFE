namespace ReviewMe.Frontend.Services
{
    public interface IHttpClientService
    {
        Task<T?> GetJsonAsync<T>(string requestUri);
        Task DeleteAsync(string requestUri);
        Task PostJsonAsync(string requestUri, object content);
    }
}