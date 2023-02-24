using System.Threading.Channels;

namespace Module2_3;

public class ShoppingCard
{
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public void Add(OrderItem product)
    {
        OrderItems.Add(product);
    }

    public void Add(Product product, int quantity)
    {
        var existingProduct = OrderItems.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Quantity += quantity;
        }
        else
        {
            OrderItems.Add(new OrderItem(product, quantity));
        }
    }
}