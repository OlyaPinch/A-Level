using Infrastructure.Data.Entities;

namespace Basket.Host.Models;

public class ProductItem
{
    public string UserId { get; set; } = "";
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? PictureUri { get; set; }
    public string? Name { get; set; }
}