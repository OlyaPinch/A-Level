#pragma warning disable CS8618

using Infrastructure.Data.Abstractions;

namespace Infrastructure.Data.Entities;

public class CatalogItem : EntityBase
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; }

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    public int AvailableStock { get; set; }
}