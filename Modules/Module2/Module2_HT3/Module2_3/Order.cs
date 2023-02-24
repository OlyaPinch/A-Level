using System.Text;

namespace Module2_3;

public class Order
{
    public Order(List<OrderItem> orderItems, int orderNumber, Guid userId)
    {
        OrderItems = orderItems;
        OrderNumber = orderNumber;
        UserId = userId;
    }

    public Guid UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public int OrderNumber { get; set; }

    public string Print()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Order N {OrderNumber}");
        sb.AppendLine($"{"Name product",-20}\t{"Quantity",10}\tSum");
        sb.AppendLine(new string('_', 50));
        foreach (var orderItem in OrderItems)
        {
            sb.AppendLine(
                $"{orderItem.Product.Name,-20}\t{orderItem.Quantity,10}\t{orderItem.Product.Price * orderItem.Quantity}");
        }

        sb.AppendLine(new string('_', 50));
        sb.AppendLine("Total: " + OrderItems.Sum(i => i.Quantity * i.Product.Price));

        return sb.ToString();
    }
}