// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Recipe;

public readonly record struct RecipeId(Guid Value);

/// <summary>
/// Represents a recipe for a cocktail, containing instructions and a list of ingredients.
/// </summary>
public class RecipeAggregate : Aggregate<RecipeId>
{
    private readonly List<IngredientAggregate> _ingredients = new();

    private RecipeAggregate(): base() {} // Private constructor for EF Core
    
    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <param name="ingredients">The list of <see cref="IngredientAggregate"/> aggregates necessary for preparing the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the recipe</param>
    private RecipeAggregate(string name, string instructions, IEnumerable<IngredientAggregate> ingredients, RecipeId? recipeId = null) : base()
    {
        Validate(name, instructions);
        Name = name.Trim();
        Instructions = instructions.Trim();
        _ingredients.AddRange(ingredients);
    }

    /// <summary>
    /// Gets the name of the recipe.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the instructions for preparing the cocktail.
    /// </summary>
    public string Instructions { get; }

    /// <summary>
    /// Gets a read-only list of ingredients required for the recipe.
    /// </summary>
    /// <remarks>
    /// Returns a copy of the internal list to prevent external modifications.
    /// </remarks>
    public IEnumerable<IngredientAggregate> Ingredients => _ingredients.AsReadOnly();

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <param name="ingredients">The list of <see cref="IngredientAggregate"/> aggregates necessary for preparing the cocktail.</param>
    /// <returns>A new <see cref="RecipeAggregate"/> instance.</returns>
    public static RecipeAggregate Create(string name, string instructions, IEnumerable<IngredientAggregate> ingredients) => new(name, instructions, ingredients);

    /// <summary>
    /// Adds an ingredient to the recipe if it doesn't already exist.
    /// </summary>
    /// <param name="ingredientAggregate">The ingredient to add.</param>
    /// <exception cref="DomainException">Thrown when the ingredient already exists in the recipe.</exception>
    public void AddIngredient(IngredientAggregate ingredientAggregate)
    {
        var existingIngredient = _ingredients.Any(i => i.Equals(ingredientAggregate));
        if (existingIngredient) throw DomainException.For<RecipeAggregate>("Ingredient is already used in the recipe.");

        _ingredients.Add(ingredientAggregate);
    }

    /// <summary>
    /// Removes an ingredient from the recipe.
    /// </summary>
    /// <param name="ingredientAggregate">The ingredient to remove.</param>
    /// <exception cref="DomainException{Recipe}">Thrown when the ingredient doesn't exist in the recipe.</exception>
    public void RemoveIngredient(IngredientAggregate ingredientAggregate)
    {
        var existingIngredient = _ingredients.FirstOrDefault(i => i.Equals(ingredientAggregate));
        if (existingIngredient is null) throw DomainException.For<RecipeAggregate>("Ingredient not found in the recipe.");

        _ingredients.Remove(ingredientAggregate);
    }

    /// <summary>
    /// Validates the recipe instructions.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <param name="instructions">The instructions to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string name, string instructions)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<RecipeAggregate>("Recipe name cannot be empty.");
        if (string.IsNullOrWhiteSpace(instructions)) throw DomainException.For<RecipeAggregate>("Recipe instructions cannot be empty.");
    }
}
