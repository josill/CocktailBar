using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Domain.Aggregates.Recipe;

public readonly record struct RecipeIngredientsAggregateId(Guid Value);

/// <summary>
/// Represents the ingredient in a recipe.
/// </summary>
public class RecipeIngredientsAggregate : Aggregate<RecipeIngredientsAggregateId>
{
    private RecipeIngredientsAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeIngredientsAggregate"/> class.
    /// </summary>
    /// <param name="recipeId">The recipe id.</param>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    private RecipeIngredientsAggregate(RecipeId recipeId, IngredientId ingredientId, Amount amount)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Amount = amount;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeIngredientsAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the relation.</param>
    /// <param name="recipeId">The recipe id.</param>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    private RecipeIngredientsAggregate(RecipeIngredientsAggregateId id, RecipeId recipeId, IngredientId ingredientId, Amount amount) : base(id)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Amount = amount;
    }

    /// <summary>
    /// Gets the amount if the ingredient used in the recipe.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// Gets the recipe id.
    /// </summary>
    public RecipeId RecipeId { get; }

    /// <summary>
    /// Gets the ingredient id.
    /// </summary>
    public IngredientId IngredientId { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeIngredientsAggregate"/> class.
    /// </summary>
    /// <param name="recipeId">The recipe id.</param>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    /// <returns>a new <see cref="RecipeIngredientsAggregate"/> instance.</returns>
    public static RecipeIngredientsAggregate Create(RecipeId recipeId, IngredientId ingredientId, Amount amount) => new(recipeId, ingredientId, amount);

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeIngredientsAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the relation.</param>
    /// <param name="recipeId">The recipe id.</param>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The amount of the ingredient used in the recipe.</param>
    /// <returns>a new <see cref="RecipeIngredientsAggregate"/> instance.</returns>
    public static RecipeIngredientsAggregate Create(RecipeIngredientsAggregateId id, RecipeId recipeId, IngredientId ingredientId, Amount amount) => new(id, recipeId, ingredientId, amount);
}
