namespace Catalog.Host.Models;

public class PaginatedItems<T>
{
    public long TotalCount { get; init; }

    public IEnumerable<T> Data { get; init; } = null!;
}