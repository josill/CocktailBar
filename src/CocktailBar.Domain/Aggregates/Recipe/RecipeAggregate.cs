// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using System.Collections.ObjectModel;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Domain.Aggregates.Recipe;

public readonly record struct RecipeId(Guid Value);

/// <summary>
/// Represents a recipe for a cocktail, containing instructions and a list of ingredients.
/// </summary>
public class RecipeAggregate : Aggregate<RecipeId>
{
    private readonly List<RecipeIngredient> _ingredients = [];

    private RecipeAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    private RecipeAggregate(string name, string instructions)
    {
        Validate(name, instructions);
        Name = name.Trim();
        Instructions = instructions.Trim();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the recipe.</param>
    /// <param name="name">the name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <remarks>This constructor should only be used for seeding data.</remarks>
    private RecipeAggregate(RecipeId id, string name, string instructions) : base(id)
    {
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
    /// Gets the list of ingredients used in the recipe.
    /// </summary>
    public IEnumerable<RecipeIngredient> Ingredients =>
        new ReadOnlyCollection<RecipeIngredient>(_ingredients);

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <returns>A new <see cref="RecipeAggregate"/> instance.</returns>
    public static RecipeAggregate Create(string name, string instructions) => new(name, instructions);

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the recipe.</param>
    /// <param name="name">The name of the recipe.</param>
    /// <param name="instructions">The instructions for preparing the cocktail.</param>
    /// <returns>A new <see cref="RecipeAggregate"/> instance.</returns>
    /// <remarks>This method should only be used for seeding data.</remarks>
    public static RecipeAggregate Create(RecipeId id, string name, string instructions) => new(id, name, instructions);

    /// <summary>
    /// Adds a new ingredient to the recipe if it's not already included.
    /// </summary>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The ingredient amount.</param>
    /// <exception cref="DomainException">Thrown when the ingredient is already present in the recipe.</exception>
    public void AddIngredient(IngredientId ingredientId, Amount amount)
    {
        var recipeIngredient = RecipeIngredient.Create(Id, ingredientId, amount);
        if (_ingredients.Contains(recipeIngredient))
            throw DomainException.For<RecipeAggregate>("Ingredient is already used in the recipe!");

        _ingredients.Add(recipeIngredient);
    }

    /// <summary>
    /// Removes an ingredient from the recipe if it exists.
    /// </summary>
    /// <param name="ingredientId">The ingredient id.</param>
    /// <param name="amount">The ingredient amount.</param>
    /// <exception cref="DomainException">Thrown when the ingredient is not found in the recipe.</exception>
    public void RemoveIngredient(IngredientId ingredientId, Amount amount)
    {
        var recipeIngredient = RecipeIngredient.Create(Id, ingredientId, amount);
        if (!_ingredients.Contains(recipeIngredient))
            throw DomainException.For<RecipeAggregate>("Ingredient not found in the recipe!");

        _ingredients.Remove(recipeIngredient);
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
