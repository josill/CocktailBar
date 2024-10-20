// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.Entities;

using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common;

/// <summary>
/// Represents a recipe for a cocktail, containing instructions and a list of ingredients.
/// </summary>
public class Recipe : EntityWithMetadata<RecipeId>
{
    private readonly List<Ingredient> _ingredients = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Recipe"/> class.
    /// </summary>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    private Recipe(string instructions) : base(RecipeId.CreateUnique())
    {
        Validate(instructions);
        Instructions = instructions;
    }

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
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.ToList().AsReadOnly();

    /// <summary>
    /// Creates a new instance of the <see cref="Recipe"/> class.
    /// </summary>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <returns>A new <see cref="Recipe"/> instance.</returns>
    public static Recipe Create(string instructions) => new(instructions);

    /// <summary>
    /// Adds an ingredient to the recipe if it doesn't already exist.
    /// </summary>
    /// <param name="ingredient">The ingredient to add.</param>
    /// <exception cref="IngredientAlreadyExistsInTheRecipe">Thrown when the ingredient already exists in the recipe.</exception>
    public void AddIngredient(Ingredient ingredient)
    {
        var existingIngredient = _ingredients.Any(i => i.Equals(ingredient));
        Guard.Against.Requires<IngredientAlreadyExistsInTheRecipe>(!existingIngredient);

        _ingredients.Add(ingredient);
    }

    /// <summary>
    /// Adds an ingredient to the recipe if it doesn't already exist.
    /// </summary>
    /// <param name="ingredient">The ingredient to add.</param>
    /// <exception cref="IngredientAlreadyExistsInTheRecipe">Thrown when the ingredient already exists in the recipe.</exception>
    public void RemoveIngredient(Ingredient ingredient)
    {
        var existingIngredient = _ingredients.FirstOrDefault(i => i.Equals(ingredient));
        Guard.Against.Requires<IngredientDoesntExistInTheRecipe>(existingIngredient != null);

        _ingredients.Remove(ingredient);
    }

    /// <summary>
    /// Validates the recipe instructions.
    /// </summary>
    /// <param name="instructions">The instructions to validate.</param>
    /// <exception cref="RecipeInstructionsCannotBeEmpty">Thrown when instructions are null, empty, or whitespace.</exception>
    private static void Validate(string instructions)
    {
        Guard.Against.Requires<RecipeInstructionsCannotBeEmpty>(!string.IsNullOrWhiteSpace(instructions));
    }
}
