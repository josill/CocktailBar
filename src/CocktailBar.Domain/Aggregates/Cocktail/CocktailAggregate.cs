// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
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
    /// <param name="id">Unique identifier of the cocktail.</param>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    private CocktailAggregate(CocktailId id, string name, string description, RecipeId recipeId) : base(id)
    {
        Validate(name, description);
        Name = name.Trim();
        Description = description.Trim();
        RecipeId = recipeId;
    }

    private CocktailAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Gets the name of the cocktail.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the cocktail.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the unique identifier of the recipe associated with this cocktail.
    /// </summary>
    public RecipeId RecipeId { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="CocktailAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    /// <returns>A new <see cref="CocktailAggregate"/> instance.</returns>
    public static CocktailAggregate Create(string name, string description, RecipeId recipeId)
    {
        var id = new CocktailId(Guid.NewGuid());
        return new CocktailAggregate(id, name, description, recipeId);
    }

    /// <summary>
    /// Validates the cocktail's name and description.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <param name="description">The description to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<CocktailAggregate>("Cocktail name can not be empty.");
        if (string.IsNullOrWhiteSpace(description)) throw DomainException.For<CocktailAggregate>("Cocktail description can not be empty.");
    }
}
