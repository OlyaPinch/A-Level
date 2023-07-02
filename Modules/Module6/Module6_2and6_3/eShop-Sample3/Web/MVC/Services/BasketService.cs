using System.Diagnostics;
using Basket.Host.Models;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Response;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Enums;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class BasketService : IBasketService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<BasketService> _logger;
    private readonly ICatalogService _catalogService;


    public BasketService(IHttpClientService httpClient, ILogger<BasketService> logger, IOptions<AppSettings> settings, ICatalogService catalogService)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
        _catalogService = catalogService;
    }

    public async Task<List<BasketDataItem>> GetBasket()
    {
        var result = await _httpClient.SendAsync<DataResponse<List<BasketDataItem>>>(
            $"{_settings.Value.BasketUrl}/Get",
            HttpMethod.Post);

        return result.Data;
    }

    public async Task AddItem(CatalogItem model)
    {
        var item = await _catalogService.GetItemById(model.Id);
        var result = await _httpClient.SendAsync<DataResponse<string>>(
            $"{_settings.Value.BasketUrl}/Add", HttpMethod.Post,
            new DataRequest<BasketDataItem>()
            {
                Data = new BasketDataItem()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = 1,
                   Price = item.Price
                   }
            });
    }
}