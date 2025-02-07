// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Contracts.Cocktails;

/// <summary>
/// Represents a request to create a new cocktail.
/// </summary>
/// <param name="Name">The name of the cocktail.</param>
/// <param name="Description">A brief description of the cocktail.</param>
/// <param name="RecipeId">The id for the recipe object of the cocktail.</param>
public record CreateCocktailRequest(
    string Name,
    string Description,
    Guid RecipeId);
