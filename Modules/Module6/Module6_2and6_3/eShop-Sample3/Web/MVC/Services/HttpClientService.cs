using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpClientService(IHttpClientFactory clientFactory,IHttpContextAccessor httpContextAccessor)
    {
        _clientFactory = clientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content)
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;
        var tokenAsync = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

        if (tokenAsync is not null)
        {
            httpMessage.Headers.Add("Authorization", $"Bearer {tokenAsync}");
        }


        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response;
        }

        return default(TResponse) !;
    }
}