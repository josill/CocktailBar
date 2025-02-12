// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Aggregates.Cocktail;

/// <summary>
/// Represents a read-only view model for cocktail data in the CocktailBar application.
/// This record is designed for query operations following the CQRS pattern.
/// </summary>
public sealed record CocktailReadModel // TODO: CocktailReadDTO?
{
    /// <summary>
    /// Gets the unique identifier for the cocktail.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the name of the cocktail.
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Gets the description of the cocktail.
    /// </summary>
    public string Description { get; init; } = default!;

    /// <summary>
    /// Gets the unique identifier of the related recipe of the cocktail.
    /// </summary>
    public Guid RecipeId { get; init; } = default!;
}
