namespace Module2_HT2;

public class OrderItem
{
    public OrderItem(IBakingSweet orderItems, int quantity)
    {
        OrderItems = orderItems;
        Quantity = quantity;
    }

    public IBakingSweet OrderItems { get; }

    public int Quantity { get; set; }
}