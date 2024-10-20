// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using CocktailBar.Domain.Common;

/// <summary>
/// Represents a unique identifier for an ingredient in the cocktail domain.
/// </summary>
public sealed class IngredientId : ValueObject<IngredientId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientId"/> class.
    /// </summary>
    /// <param name="value">The GUID value to use for this IngredientId.</param>
    /// <remarks>
    /// This constructor is private to enforce creation through the <see cref="CreateUnique"/> method.
    /// </remarks>
    private IngredientId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the underlying GUID value of the IngredientId.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new unique IngredientId.
    /// </summary>
    /// <returns>A new instance of <see cref="IngredientId"/> with a unique GUID value.</returns>
    public static IngredientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}
