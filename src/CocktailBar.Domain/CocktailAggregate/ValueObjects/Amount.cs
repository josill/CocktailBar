// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Classes;
using CocktailBar.Domain.Common.Enums;
using CocktailBar.Domain.Common.Errors;

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects;

using System.Collections.Generic;
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
    private Amount(decimal value, WeightUnit unit)
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
    public WeightUnit Unit { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="Amount"/> class.
    /// </summary>
    /// <param name="value">The numeric value of the amount.</param>
    /// <param name="unit">The unit of measurement for the amount.</param>
    /// <returns>A new <see cref="Amount"/> instance.</returns>
    public static Amount Create(decimal value, WeightUnit unit) => new(value, unit);

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
        yield return Unit;
    }

    /// <summary>
    /// Adds two amount value objects together.
    /// </summary>
    /// <param name="other">The amount to add.</param>
    /// <returns>A new <see cref="Amount"/> instance.</returns>
    /// <exception cref="DomainException{Amount}">Thrown when units don't match.</exception>
    protected override Amount Add(Amount other)
    {
        DomainException.For<Amount>(other.Unit != Unit, "Units don't match while adding weights.");
        return new Amount(Value + other.Value, Unit);
    }

    /// <summary>
    /// Validates the given value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <exception cref="DomainException{Weight}">Thrown when validation fails.</exception>
    private static void Validate(decimal value)
    {
        DomainException.For<Amount>(value % 0.001m != 0, "Weight value cannot have more than three decimal places.");
        DomainException.For<Amount>(value < 0, "Weight cannot be a negative value.");
    }
}
