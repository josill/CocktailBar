// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

namespace CocktailBar.Domain.CocktailAggregate.Entities;

using CocktailBar.Domain.CocktailAggregate.ValueObjects;
using CocktailBar.Domain.Common;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

/// <summary>
/// Represents an ingredient in a cocktail recipe.
/// </summary>
public class Ingredient : AggregateRoot<IngredientId>
{
    private readonly List<Recipe> _recipes = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    private Ingredient(StockItemId stockItemId, Amount amount) : base(IngredientId.New())
    {
        StockItemId = stockItemId;
        Amount = amount;
    }
    
    private Ingredient() { }

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
    public List<Recipe> Recipes => _recipes.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    /// <returns>A new <see cref="Ingredient"/> instance.</returns>
    public static Ingredient Create(StockItemId stockItemId, Amount amount) => new(stockItemId, amount);
}
