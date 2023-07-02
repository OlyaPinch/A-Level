using Infrastructure.Data.Entities;

namespace Basket.Host.Models;

public class BasketData
{
     public string BuyerId { get; set; }

     public List<BasketDataItem> Items { get; set; } = new();

    
     public BasketData(string buyerId)
     {
          BuyerId = buyerId;
     }
}
