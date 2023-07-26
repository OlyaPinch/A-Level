using Infrastructure.Models.Basket;
using Infrastructure.Models.Order;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Response;
using MVC.Services.Interfaces;
using NSubstitute.ReceivedExtensions;

namespace MVC.Services;

public class OrderService:IOrderService
{ private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<BasketService> _logger;

    public OrderService(IOptions<AppSettings> settings, IHttpClientService httpClient, ILogger<BasketService> logger)
    {
        _settings = settings;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task AddItem(List<BasketDataItem> Basket)
    { 
        
        var result = await _httpClient.SendAsync<DataRequest<BasketData>>(
            $"{_settings.Value.BasketUrl}/Add", HttpMethod.Post,
            new DataRequest<BasketData>()
            {
                Data = new BasketData("1")
                {
                    
                    Items= Basket,
                    
                }
            });
    }

    public async Task<List<OrderItemData>> GetOrderItems()
    {
        var result = await _httpClient.SendAsync<DataResponse<List<OrderItemData>>>(
            $"{_settings.Value.BasketUrl}/Get",
            HttpMethod.Post);

        return result.Data;
    }



}