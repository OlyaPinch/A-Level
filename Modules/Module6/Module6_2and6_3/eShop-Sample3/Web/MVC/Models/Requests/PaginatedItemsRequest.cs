using Infrastructure.Models.Requests;

namespace MVC.Dtos;

public class PaginatedItemsRequest<T>: PaginatedItemsRequest
{
  public T Filter { get; set; }
}

public class CatalogFilter
{
    public int BrandId { get; set; }
    public int TypeId { get; set; }
}