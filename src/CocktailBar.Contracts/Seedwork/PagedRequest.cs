namespace CocktailBar.Contracts.Seedwork;

public record PagedRequest
{
    /// <summary>
    /// Gets the page number.
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Gets the page size.
    /// </summary>
    public int PageSize { get; init; } = 50;
}
