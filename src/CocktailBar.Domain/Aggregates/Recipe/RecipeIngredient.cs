using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Domain.Aggregates.Recipe;

public readonly record struct RecipeIngredientsAggregateId(Guid Value);

/// <summary>
/// Represents the ingredient in a recipe.
/// </summary>
public class RecipeIngredient : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeIngredient"/> class.
    /// </summary>
    /// <param name="recipeId">The unique identifier of the recipe that this ingredient belongs to.</param>
    /// <param name="ingredientId">The unique identifier of the ingredient from the ingredient catalog.</param>
    /// <param name="amount">The quantity and unit of measurement for this ingredient in the recipe.</param>
    internal RecipeIngredient(RecipeId recipeId, IngredientId ingredientId, Amount amount)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Amount = amount;
    }

    /// <summary>
    /// Gets the recipe id.
    /// </summary>
    public RecipeId RecipeId { get; }

    /// <summary>
    /// Gets the ingredient id.
    /// </summary>
    public IngredientId IngredientId { get; }

    /// <summary>
    /// Gets the amount if the ingredient used in the recipe.
    /// </summary>
    public Amount Amount { get; }
}
