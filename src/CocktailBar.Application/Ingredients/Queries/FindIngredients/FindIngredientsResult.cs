using CocktailBar.Application.Common.Interfaces.Querying;
using CocktailBar.Application.Common.Results;
using CocktailBar.Domain.Aggregates.Ingredient;

namespace CocktailBar.Application.Ingredients.Queries.FindIngredients;

public record FindIngredientsResult(List<IngredientAggregate> Items, int Page, int PageSize) : PagedResult<IngredientAggregate>(Items, Page, PageSize)
{
    public static FindIngredientsResult From(IPaginatedList<IngredientAggregate> ingredients)
    {
        return new FindIngredientsResult(ingredients.Items, ingredients.Page, ingredients.PageSize);
    }
}
