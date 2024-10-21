// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Contracts.Cocktails;

/// <summary>
/// Represents a request to create a new cocktail.
/// </summary>
/// <param name="Name">The name of the cocktail.</param>
/// <param name="Description">A brief description of the cocktail.</param>
/// <param name="Recipe">The recipe for making the cocktail.</param>
public record CreateCocktailRequest(
    string Name,
    string Description,
    Recipe Recipe);

/// <summary>
/// Represents a recipe for making a cocktail.
/// </summary>
/// <param name="Instructions">Step-by-step instructions for preparing the cocktail.</param>
/// <param name="Ingredients">A list of ingredients required for the cocktail.</param>
public record Recipe(
    string Instructions,
    List<Ingredient> Ingredients);

/// <summary>
/// Represents an ingredient in a cocktail recipe.
/// </summary>
/// <param name="StockItemId">The unique identifier for the stock item used as an ingredient.</param>
/// <param name="Amount">The quantity and unit of measurement for the ingredient.</param>
public record Ingredient(
    string StockItemId,
    Amount Amount);

/// <summary>
/// Represents the amount of an ingredient used in a recipe.
/// </summary>
/// <param name="Value">The numeric value of the amount.</param>
/// <param name="Unit">The unit of measurement (e.g., "oz", "ml", "piece").</param>
public record Amount(
    decimal Value,
    string Unit);
