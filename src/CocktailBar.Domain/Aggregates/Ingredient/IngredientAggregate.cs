// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

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
    private readonly List<Recipe.RecipeAggregate> _recipes = new();

    private IngredientAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    private IngredientAggregate(StockItemId stockItemId, Amount amount)
    {
        StockItemId = stockItemId;
        Amount = amount;
    }

    /// <summary>
    /// Gets the unique identifier of the stock item associated with this ingredient.
    /// </summary>
    public StockItemId StockItemId { get; }

    /// <summary>
    /// Gets the amount of the ingredient required in the recipe.
    /// </summary>
    public Amount Amount { get; }

    /// <summary>
    /// Gets a read-only list of the recipes where the ingredient is used.
    /// </summary>
    /// <remarks>
    /// Returns a copy of the internal list to prevent external modification.
    /// </remarks>
    public List<Recipe.RecipeAggregate> Recipes => _recipes.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    public static IngredientAggregate Create(StockItemId stockItemId, Amount amount) => new(stockItemId, amount);
}
