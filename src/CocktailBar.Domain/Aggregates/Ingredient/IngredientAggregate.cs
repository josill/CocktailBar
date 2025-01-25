// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

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
    /// <param name="name">The name of the ingredient.</param>
    private IngredientAggregate(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the ingredient.</param>
    /// <param name="name">The name of the ingredient.</param>
    /// <remarks>This constructor should only be used for seeding data.</remarks>
    private IngredientAggregate(IngredientId id, string name) : base(id)
    {
        Name = name;
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
    public static IngredientAggregate Create(string name) => new(name);

    /// <summary>
    /// Creates a new instance of the <see cref="IngredientAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the ingredient.</param>
    /// <param name="name">The name of the ingredient.</param>
    /// <returns>A new <see cref="IngredientAggregate"/> instance.</returns>
    /// <remarks>This method should only be used for seeding data.</remarks>
    public static IngredientAggregate Create(IngredientId id, string name) => new(id, name);
}
