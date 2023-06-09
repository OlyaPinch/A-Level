#pragma warning disable CS8618
using Infrastructure.Data.Abstractions;

namespace Infrastructure.Data.Entities;

public class CatalogBrand : EntityBase
{
    public string Brand { get; set; }
}