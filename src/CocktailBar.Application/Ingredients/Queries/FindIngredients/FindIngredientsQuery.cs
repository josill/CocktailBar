using CocktailBar.Application.Common.Queries;

namespace CocktailBar.Application.Ingredients.Queries.FindIngredients;

public record FindIngredientsQuery(int Page, int PageSize) : PagedQuery<FindIngredientsResult>(Page, PageSize);
