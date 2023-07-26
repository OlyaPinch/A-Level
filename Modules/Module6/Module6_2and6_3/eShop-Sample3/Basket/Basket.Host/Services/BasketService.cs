using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Data.Entities;
using Infrastructure.Models.Basket;
using Infrastructure.Models.Response;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
    
    
    public async Task Add(ProductItem basket, string? basketId)
    {
        
        var currentBasket = await _cacheService.GetAsync<BasketData>(basketId!)?? new BasketData(basket.UserId);
        var product = currentBasket.Items.SingleOrDefault(i => i.Id == basket.Id);
        
        if (product != null)
        {
            // Step 4: Update quantity for product
            product.Quantity += basket.Quantity;
        }
        else
        {
            // Step 4: Merge current status with new product
            currentBasket.Items.Add(new BasketDataItem()
            {
                Price = basket.Price,
                PictureUrl = basket.PictureUri,
                Id = basket.Id,
                Name = basket.Name,
                Quantity = basket.Quantity
                
            });
        }
       await _cacheService.AddOrUpdateAsync(basketId!, currentBasket);
    }

    public async Task<DataResponse<List<BasketDataItem>>> Get(string userId)
    {
        var result = await _cacheService.GetAsync<BasketData>(userId);
        return new DataResponse<List<BasketDataItem>>() { Data = result.Items };
    }
    
    
}