// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Read;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.Seedwork.Errors;

namespace CocktailBar.Domain.CocktailAggregate.Entities;

/// <summary>
/// Represents a cocktail in the domain model.
/// </summary>
public class Cocktail : Aggregate<CocktailId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Cocktail"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    /// <param name="cocktailId">The unique identifier of the cocktail</param>
    private Cocktail(string name, string description, RecipeId recipeId, CocktailId? cocktailId = null) : base(cocktailId ?? new CocktailId(Guid.NewGuid()))
    {
        Validate(name, description);
        Name = name;
        Description = description;
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
    /// Creates a new instance of the <see cref="Cocktail"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    /// <returns>A new <see cref="Cocktail"/> instance.</returns>
    public static Cocktail Create(
        string name, string description, RecipeId recipeId) => new(name, description, recipeId);

    /// <summary>
    /// Creates a new instance of the <see cref="Cocktail"/> class from the <see cref="CocktailReadModel"/> class.
    /// </summary>
    /// <param name="cocktail">The cocktail read model.</param>
    /// <returns>A new <see cref="Cocktail"/> instance.</returns>
    public static Cocktail From(CocktailReadModel cocktail) => new(
        cocktail.Name,
        cocktail.Description,
        new RecipeId(cocktail.RecipeId),
        new CocktailId(cocktail.Id));

    /// <summary>
    /// Validates the cocktail's name and description.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <param name="description">The description to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<Cocktail>("Cocktail name can not be empty.");
        if (string.IsNullOrWhiteSpace(description)) throw DomainException.For<Cocktail>("Cocktail description can not be empty.");
    }
}
