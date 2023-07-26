using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    [Column(TypeName = "Money")]
    public decimal Price { get; set; }

    public string PictureUrl { get; set; }

    public CatalogTypeDto CatalogType { get; set; }

    public CatalogBrandDto CatalogBrand { get; set; }

    public int AvailableStock { get; set; }
}