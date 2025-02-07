// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Ingredient;

public readonly record struct IngredientId(Guid Value);

/// <summary>
/// Represents an ingredient.
/// </summary>
public class IngredientAggregate : Aggregate<IngredientId>
{
    private IngredientAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the ingredient.</param>
    /// <param name="name">The name of the ingredient.</param>
    /// <remarks>This constructor should only be used for seeding data.</remarks>
    private IngredientAggregate(IngredientId id, string name) : base(id)
    {
        Validate(name);
        Name = name.Trim();
    }

    /// <summary>
    /// Gets the name of the ingredient.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    public static IngredientAggregate Create(string name)
    {
        var id = new IngredientId(Guid.NewGuid());
        return new IngredientAggregate(id, name);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the ingredient.</param>
    /// <param name="name">The name of the ingredient.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    /// <remarks>This method should only be used for seeding data.</remarks>
    public static IngredientAggregate Create(IngredientId id, string name) => new(id, name);

    /// <summary>
    /// Validates the ingredient name.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<IngredientAggregate>("Ingredient name can not be empty.");
    }
}
