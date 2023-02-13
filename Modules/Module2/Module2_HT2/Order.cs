namespace Module2_HT2;

public class Order
{
    public Order(OrderItem[] order)
    {
        Items = order;
    }

    public OrderItem[] Items { get; }
}