// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Read;
using CocktailBar.Domain.Common.Errors;

namespace CocktailBar.Domain.CocktailAggregate.Entities;

using System.Collections.Generic;
using System.Linq;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common;

/// <summary>
/// Represents a recipe for a cocktail, containing instructions and a list of ingredients.
/// </summary>
public class Recipe : EntityWithMetadata<RecipeId>
{
    private readonly List<Ingredient> _ingredients = new();

    private Recipe() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Recipe"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the recipe</param>
    private Recipe(string name, string instructions, RecipeId? recipeId = null) : base(recipeId ?? RecipeId.New())
    {
        Validate(name, instructions);
        Name = name;
        Instructions = instructions;
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
    public List<Ingredient> Ingredients => _ingredients.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="Recipe"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <returns>A new <see cref="Recipe"/> instance.</returns>
    public static Recipe Create(string name, string instructions) => new(name, instructions);

    /// <summary>
    /// Adds an ingredient to the recipe if it doesn't already exist.
    /// </summary>
    /// <param name="ingredient">The ingredient to add.</param>
    /// <exception cref="DomainException{Recipe}">Thrown when the ingredient already exists in the recipe.</exception>
    public void AddIngredient(Ingredient ingredient)
    {
        var existingIngredient = _ingredients.Any(i => i.Equals(ingredient));
        DomainException.For<Recipe>(existingIngredient, "Ingredient is already used in the recipe.");

        _ingredients.Add(ingredient);
    }

    /// <summary>
    /// Removes an ingredient from the recipe.
    /// </summary>
    /// <param name="ingredient">The ingredient to remove.</param>
    /// <exception cref="DomainException{Recipe}">Thrown when the ingredient doesn't exist in the recipe.</exception>
    public void RemoveIngredient(Ingredient ingredient)
    {
        var existingIngredient = _ingredients.FirstOrDefault(i => i.Equals(ingredient));
        DomainException.For<Recipe>(existingIngredient == null, "Ingredient not found in the recipe.");

        _ingredients.Remove(ingredient);
    }

    /// <summary>
    /// Validates the recipe instructions.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <param name="instructions">The instructions to validate.</param>
    /// <exception cref="DomainException{Recipe}">Thrown when validation fails.</exception>
    private static void Validate(string name, string instructions)
    {
        DomainException.For<Recipe>(string.IsNullOrWhiteSpace(name), "Recipe name cannot be empty.");
        DomainException.For<Recipe>(string.IsNullOrWhiteSpace(instructions), "Recipe instructions cannot be empty.");
    }
}
