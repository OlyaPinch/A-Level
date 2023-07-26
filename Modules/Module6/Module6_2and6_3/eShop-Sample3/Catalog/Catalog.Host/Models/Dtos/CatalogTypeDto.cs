using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogTypeDto
{[Key]
    public int Id { get; set; }
[Required]
    public string Type { get; set; }
}