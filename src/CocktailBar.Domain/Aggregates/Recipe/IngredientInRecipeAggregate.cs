using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Domain.Aggregates.Recipe;

public readonly record struct IngredientInRecipeAggregateId(Guid Value);

/// <summary>
/// Represents the ingredient in a recipe.
/// </summary>
public class IngredientInRecipeAggregate : Aggregate<IngredientInRecipeAggregateId>
{
    private IngredientInRecipeAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientInRecipeAggregate"/> class.
    /// </summary>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    private IngredientInRecipeAggregate(Amount amount)
    {
        Amount = amount;
    }

    /// <summary>
    /// Gets the amount if the ingredient used in the recipe.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientInRecipeAggregate"/> class.
    /// </summary>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    /// <returns>a new <see cref="IngredientInRecipeAggregate"/> instance.</returns>
    public static IngredientInRecipeAggregate Create(Amount amount) => new(amount);
}
