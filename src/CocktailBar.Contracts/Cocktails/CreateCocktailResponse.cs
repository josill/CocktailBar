// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Contracts.Cocktails;

/// <summary>
/// Represents the response after successfully creating a new cocktail.
/// </summary>
/// <param name="Name">The name of the created cocktail.</param>
/// <param name="Description">A brief description of the created cocktail.</param>
/// <param name="Recipe">The recipe of the created cocktail.</param>
public record CreateCocktailResponse(
    string Name,
    string Description,
    RecipeResponse Recipe);

/// <summary>
/// Represents the response containing the recipe details of a cocktail.
/// </summary>
/// <param name="Instructions">Step-by-step instructions for preparing the cocktail.</param>
/// <param name="Ingredients">A list of ingredients required for the cocktail.</param>
public record RecipeResponse(
    string Instructions,
    List<IngredientResponse> Ingredients);

/// <summary>
/// Represents the response containing details of an ingredient in a cocktail recipe.
/// </summary>
/// <param name="StockItemId">The unique identifier for the stock item used as an ingredient.</param>
/// <param name="Amount">The quantity and unit of measurement for the ingredient.</param>
public record IngredientResponse(
    string StockItemId,
    AmountResponse Amount);

/// <summary>
/// Represents the response containing the amount details of an ingredient.
/// </summary>
/// <param name="Value">The numeric value of the amount.</param>
/// <param name="Unit">The unit of measurement (e.g., "oz", "ml", "piece").</param>
public record AmountResponse(
    decimal Value,
    string Unit);
