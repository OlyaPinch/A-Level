using Infrastructure.Data.Abstractions;

namespace Infrastructure.Models.Order;

public class OrderData: EntityBase
{
    public string OrderNumber { get; }

    /*public DateTime Date { get; set; }

    public string Status { get; set; }

    public decimal Total { get; set; }

    public string Description { get; set; }

    public string Buyer { get; set; }*/

    public OrderData()
    {
        OrderNumber = GenerateOrderId();
    }

    public List<OrderItemData> OrderItems { get; } = new();
    
    public static string GenerateOrderId()
    {
        Guid orderIdGuid = Guid.NewGuid();
        string orderId = "ORD-" + orderIdGuid.ToString().Substring(0, 6).ToUpper();

        return orderId;
    }
}