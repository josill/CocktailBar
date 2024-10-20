// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.Entities;

using System.Collections.Generic;
using CocktailBar.Domain.CocktailAggregate.ValueObjects;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

/// <summary>
/// Represents an ingredient in a cocktail recipe.
/// </summary>
public class Ingredient : ValueObject<Ingredient>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    private Ingredient(StockItemId stockItemId, Amount amount)
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
    /// Creates a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="stockItemId">The unique identifier of the associated stock item.</param>
    /// <param name="amount">The amount of the ingredient.</param>
    /// <returns>A new <see cref="Ingredient"/> instance.</returns>
    public static Ingredient Create(StockItemId stockItemId, Amount amount) => new(stockItemId, amount);

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumerable of objects representing the attributes for equality comparison.</returns>
    /// <remarks>
    /// This method returns the StockItemId and Amount properties for use in equality comparisons.
    /// </remarks>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return StockItemId;
        yield return Amount;
    }
}
