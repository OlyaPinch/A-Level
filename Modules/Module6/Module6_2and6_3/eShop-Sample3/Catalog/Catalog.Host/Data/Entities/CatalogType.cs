#pragma warning disable CS8618
using Catalog.Host.Data.Abstactions;

namespace Catalog.Host.Data.Entities;

public class CatalogType : EntityBase
{
    public string Type { get; set; }
}