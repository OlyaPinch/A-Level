namespace Module2_3;

public class OrderItem
{
    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public Product Product { get; set; }
    public int Quantity { get; set; }
}