// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects;

using System.Collections.Generic;
using Ardalis.GuardClauses;
using CocktailBar.Domain.CocktailAggregate.Enums;
using CocktailBar.Domain.Common;

/// <summary>
/// Represents an amount with a value and a unit of measurement.
/// </summary>
public class Amount : ValueObject<Amount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Amount"/> class.
    /// </summary>
    /// <param name="value">The numeric value of the amount.</param>
    /// <param name="unit">The unit of measurement for the amount.</param>
    /// <remarks>
    /// This constructor is private to enforce creation through the <see cref="Create"/> method.
    /// </remarks>
    private Amount(decimal value, AmountUnit unit)
    {
        Validate(value);
        Value = value;
        Unit = unit;
    }

    /// <summary>
    /// Gets the numeric value of the amount.
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// Gets the unit of measurement for the amount.
    /// </summary>
    public AmountUnit Unit { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="Amount"/> class.
    /// </summary>
    /// <param name="value">The numeric value of the amount.</param>
    /// <param name="unit">The unit of measurement for the amount.</param>
    /// <returns>A new <see cref="Amount"/> instance.</returns>
    /// <exception cref="MoreThanThreeDecimalPlacesInWeightValueException">Thrown when the value has more than three decimal places.</exception>
    /// <exception cref="WeightCannotBeNegativeException">Thrown when the value is negative.</exception>
    public static Amount Create(decimal value, AmountUnit unit) => new(value, unit);

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumerable of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
        yield return Unit;
    }

    /// <summary>
    /// Validates the given value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <exception cref="MoreThanThreeDecimalPlacesInWeightValueException">Thrown when the value has more than three decimal places.</exception>
    /// <exception cref="WeightCannotBeNegativeException">Thrown when the value is negative.</exception>
    private static void Validate(decimal value)
    {
        Guard.Against.Requires<MoreThanThreeDecimalPlacesInWeightValueException>(value % 0.001m == 0);
        Guard.Against.Requires<WeightCannotBeNegativeException>(value >= 0);
    }
}
