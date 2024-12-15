// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Domain.Aggregates.Ingredient;

public readonly record struct IngredientId(Guid Value);

/// <summary>
/// Represents an ingredient in a cocktail recipe.
/// </summary>
public class IngredientAggregate : Aggregate<IngredientId>
{
    private readonly List<RecipeId> _recipeIds = [];

    private readonly List<Recipe.RecipeAggregate> _recipes = [];

    private IngredientAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="ingredientName">The name of the ingredient.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    private IngredientAggregate(IngredientName ingredientName, Amount amount, StockItemId stockItemId)
    {
        Name = ingredientName;
        Amount = amount;
        StockItemId = stockItemId;
    }

    /// <summary>
    /// Gets the name of the ingredient.
    /// </summary>
    public IngredientName Name { get; }

    /// <summary>
    /// Gets the amount of the ingredient.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// Gets the unique identifier of the stock item associated with this ingredient.
    /// </summary>
    public StockItemId StockItemId { get; }

    /// <summary>
    /// Gets a read-only list of the recipes where the ingredient is used.
    /// </summary>
    public IEnumerable<RecipeId> RecipeIds => _recipeIds.AsReadOnly().ToList();

    /// <summary>
    /// Gets a read-only list of the recipes where the ingredient is used.
    /// </summary>
    public IEnumerable<RecipeAggregate> Recipes => _recipes.AsReadOnly().ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    public static IngredientAggregate Create(IngredientName name, Amount amount, StockItemId stockItemId) => new(name, amount, stockItemId);
}
