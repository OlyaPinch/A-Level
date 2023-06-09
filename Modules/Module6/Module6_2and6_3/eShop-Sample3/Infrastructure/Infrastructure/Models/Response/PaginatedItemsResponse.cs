namespace Infrastructure.Models.Response;

public class PaginatedItemsResponse<T> : Response<T>
{
    public int PageIndex { get; init; }

    public int PageSize { get; init; }

    public long Count { get; init; }
}