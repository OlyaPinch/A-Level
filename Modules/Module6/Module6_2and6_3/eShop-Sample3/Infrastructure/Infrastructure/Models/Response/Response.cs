namespace Infrastructure.Models.Response
{
    public class Response<T>
    {
        public IEnumerable<T> Data { get; init; } = null!;
        public string? Error { get; set; } = string.Empty;
    }
}