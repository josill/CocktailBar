// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.Read;

/// <summary>
/// Represents a read-only view model for cocktail data in the CocktailBar application.
/// This record is designed for query operations following the CQRS pattern.
/// </summary>
public sealed record CocktailReadModel
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
    /// Note: Property name contains a typo and should be 'Description'.
    /// </summary>
    public string Description { get; init; } = default!;
}
