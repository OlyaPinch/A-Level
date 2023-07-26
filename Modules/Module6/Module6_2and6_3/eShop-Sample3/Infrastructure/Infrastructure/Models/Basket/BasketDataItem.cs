namespace Infrastructure.Models.Basket;

public class BasketDataItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public decimal OldUnitPrice { get; set; }

    public int Quantity { get; set; }

    public string? PictureUrl { get; set; }
}