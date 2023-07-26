using Infrastructure.Data.Abstractions;

namespace Infrastructure.Data.Entities;

public class OrderItem:EntityBase
{
    public int CatalogItemId { get; set; }
    public CatalogItem CatalogItem { get; set; }
    public int Quantiy { get; set; }
}