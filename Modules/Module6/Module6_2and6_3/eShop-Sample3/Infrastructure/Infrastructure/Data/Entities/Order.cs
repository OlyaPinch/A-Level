using Infrastructure.Data.Abstractions;

namespace Infrastructure.Data.Entities;

public class Order : EntityBase
{
    public int OrderNumber { get; set; }

    public List<OrderItem> OrderData { get; set; }
}

