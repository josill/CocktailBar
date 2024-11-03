// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Recipes.Models;

/// <summary>
/// Represents a read-only view model for recipe data in the CocktailBar application.
/// This record is designed for query operations following the CQRS pattern.
/// </summary>
public sealed record RecipeReadModel
{
    /// <summary>
    /// Gets the unique identifier for the recipe.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the name of the recipe.
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Gets the preparation instructions for the recipe.
    /// Contains step-by-step directions for creating the cocktail.
    /// </summary>
    public string Instructions { get; init; } = default!;
}
