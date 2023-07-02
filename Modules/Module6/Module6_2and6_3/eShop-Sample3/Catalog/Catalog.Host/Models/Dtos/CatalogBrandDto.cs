using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogBrandDto
{ [Key] 
    public int Id { get; set; }
    [MaxLength(10, ErrorMessage = "Brand must contain less than 10 symbols")]
    public string Brand { get; set; }
}