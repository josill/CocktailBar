// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Contracts.Recipes;

/// <summary>
/// Represents a request to create a new recipe.
/// </summary>
/// <param name="Name">The name of the recipe to create.</param>
/// <param name="Instructions">The step-by-step instructions for preparing the recipe.</param>
public record CreateRecipeRequest(string Name, string Instructions);
