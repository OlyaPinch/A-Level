namespace MVC.Services.Interfaces;

public interface IHttpClientService
{
    Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = default);
}