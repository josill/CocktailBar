// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Ingredient;

public readonly record struct IngredientId(Guid Value);

/// <summary>
/// Represents an ingredient.
/// </summary>
public class IngredientAggregate : Aggregate<IngredientId>
{
    private readonly List<Recipe.RecipeAggregate> _recipes = new();

    private IngredientAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    private IngredientAggregate(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets the name of the ingredient.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a read-only list of the recipes where the ingredient is used.
    /// </summary>
    public IEnumerable<RecipeAggregate> Recipes => _recipes.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    public static IngredientAggregate Create(string name) => new(name);
}
