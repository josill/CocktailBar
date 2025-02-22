namespace CocktailBar.Application.Common.Results;

public record PagedResult<T>(List<T> Items, int Page, int PageSize);
