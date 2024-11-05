// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Errors;

namespace CocktailBar.Domain.CocktailAggregate.Entities;

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common;

/// <summary>
/// Represents a cocktail in the domain model.
/// </summary>
public class Cocktail : AggregateRoot<CocktailId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Cocktail"/> class.
    /// </summary>
    /// <param name="name">The name of the cocktail.</param>
    /// <param name="description">The description of the cocktail.</param>
    /// <param name="recipeId">The unique identifier of the associated recipe.</param>
    private Cocktail(string name, string description, RecipeId recipeId) : base(CocktailId.New())
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
    /// Validates the cocktail's name and description.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <param name="description">The description to validate.</param>
    /// <exception cref="DomainException{Cocktail}">Thrown when validation fails.</exception>
    private static void Validate(string name, string description)
    {
        DomainException.For<Cocktail>(string.IsNullOrWhiteSpace(name), "Cocktail name can not be empty.");
        DomainException.For<Cocktail>(string.IsNullOrWhiteSpace(description), "Cocktail description can not be empty.");
    }
}
