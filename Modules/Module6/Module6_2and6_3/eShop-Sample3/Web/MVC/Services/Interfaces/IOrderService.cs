using Infrastructure.Models.Basket;
using Infrastructure.Models.Order;

namespace MVC.Services.Interfaces;

public interface IOrderService
{
    Task AddItem(List<BasketDataItem> Basket);
    Task<List<OrderItemData>> GetOrderItems();
}