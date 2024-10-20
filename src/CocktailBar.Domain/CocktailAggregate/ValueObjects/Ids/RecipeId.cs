// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using CocktailBar.Domain.Common;

/// <summary>
/// Represents a unique identifier for a recipe in the cocktail domain.
/// </summary>
public sealed class RecipeId : ValueObject<RecipeId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeId"/> class.
    /// </summary>
    /// <param name="value">The GUID value to use for this RecipeId.</param>
    /// <remarks>
    /// This constructor is private to enforce creation through the <see cref="CreateUnique"/> method.
    /// </remarks>
    private RecipeId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the underlying GUID value of the RecipeId.
    /// </summary>
    /// <remarks>
    /// This property is private to ensure immutability and encapsulation of the RecipeId.
    /// </remarks>
    private Guid Value { get; }

    /// <summary>
    /// Creates a new unique RecipeId.
    /// </summary>
    /// <returns>A new instance of <see cref="RecipeId"/> with a unique GUID value.</returns>
    public static RecipeId CreateUnique()
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
