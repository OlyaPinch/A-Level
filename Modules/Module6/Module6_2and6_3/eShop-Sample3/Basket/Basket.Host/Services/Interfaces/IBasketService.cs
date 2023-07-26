using Basket.Host.Models;
using Infrastructure.Models.Basket;
using Infrastructure.Models.Response;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task Add(ProductItem basket, string? basketId);
   
    Task<DataResponse<List<BasketDataItem>>> Get(string userId);
}