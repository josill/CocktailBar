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
    
    private CocktailAggregate() {} // Private constructor for EF Core
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    public CocktailAggregate(string name, string description, RecipeId recipeId)
    {
        Validate(name, description);
        Name = name.Trim();
        Description = description.Trim();
        RecipeId = recipeId;
    }

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
    public static CocktailAggregate Create(
        string name, string description, RecipeId recipeId) => new(name, description, recipeId);

    /// <summary>
    /// Creates a new instance of the <see cref="CocktailAggregate"/> class from the <see cref="CocktailReadModel"/> class.
    /// </summary>
    /// <param name="cocktail">The cocktail read model.</param>
    /// <returns>A new <see cref="CocktailAggregate"/> instance.</returns>
    public static CocktailAggregate From(CocktailReadModel cocktail) => new(
        cocktail.Name,
        cocktail.Description,
        new RecipeId(cocktail.RecipeId));

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
