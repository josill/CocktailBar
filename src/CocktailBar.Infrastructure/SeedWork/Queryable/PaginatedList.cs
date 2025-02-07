using CocktailBar.Application.Common.Interfaces.Querying;

namespace CocktailBar.Infrastructure.SeedWork.Queryable;

internal class PaginatedList<T> : IPaginatedList<T>
{
    public List<T> Items { get; }

    public int TotalCount { get; }

    public int Page { get; }

    public int PageSize { get; }

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasNextPage => Page < TotalPages;

    public bool HasPreviousPage => Page > 1;

    public PaginatedList(List<T> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }
}
