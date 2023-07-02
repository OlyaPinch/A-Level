namespace Infrastructure.Models.Requests;

public class PaginatedItemsRequest
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
public class PaginatedItemsRequest<T>: PaginatedItemsRequest
{
    public T Filter { get; set; }
}