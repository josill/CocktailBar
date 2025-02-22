namespace CocktailBar.Application.Common.Interfaces.Querying;

public interface IPaginatedList<T>
{
    List<T> Items { get; }

    int TotalCount { get; }

    int Page { get; }

    int PageSize { get; }

    int TotalPages { get; }

    bool HasNextPage { get; }

    bool HasPreviousPage { get; }
}
