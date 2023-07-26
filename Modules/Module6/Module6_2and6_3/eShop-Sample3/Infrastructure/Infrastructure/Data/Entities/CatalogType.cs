#pragma warning disable CS8618
using Infrastructure.Data.Abstractions;

namespace Infrastructure.Data.Entities;

public class CatalogType : EntityBase
{
    public string Type { get; set; }
}