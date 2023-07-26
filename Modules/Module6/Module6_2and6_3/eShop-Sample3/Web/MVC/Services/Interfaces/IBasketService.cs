using Infrastructure.Models.Basket;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface IBasketService
{
    Task<List<BasketDataItem>> GetBasket();
    Task AddItem(CatalogItem model);
}