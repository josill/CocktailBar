// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations.Cocktail;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Cocktail;

public readonly record struct CocktailId(Guid Value);

/// <summary>
/// Represents a cocktail in the domain model.
/// </summary>
public class CocktailAggregate : Aggregate<CocktailId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    public CocktailAggregate(CocktailName name, RecipeId recipeId)
    {
        Validate(name);
        Name = name;
        RecipeId = recipeId;
    }

    private CocktailAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Gets the name of the cocktail.
    /// </summary>
    public CocktailName Name { get; }

    /// <summary>
    /// Gets the unique identifier of the recipe associated with this cocktail.
    /// </summary>
    public RecipeId RecipeId { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="CocktailAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    /// <returns>A new <see cref="CocktailAggregate"/> instance.</returns>
    public static CocktailAggregate Create(
        CocktailName name, RecipeId recipeId) => new(name, recipeId);

    /// <summary>
    /// Validates the cocktail's name and description.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(Enumeration name)
    {
        if (string.IsNullOrWhiteSpace(name.Value)) throw DomainException.For<CocktailAggregate>("Cocktail name can not be empty.");
    }
}
