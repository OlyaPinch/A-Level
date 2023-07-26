using Infrastructure.Data.Abstractions;

namespace Infrastructure.Models.Basket;

public class BasketData : EntityBase
{
    public string BuyerId { get; set; }

    public List<BasketDataItem> Items { get; set; } = new();


    public BasketData(string buyerId)
    {
        BuyerId = buyerId;
    }
}