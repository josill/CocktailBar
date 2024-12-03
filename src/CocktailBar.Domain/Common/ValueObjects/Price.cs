// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Interfaces;
using CocktailBar.Domain.Common.Errors;
using TeixeiraSoftware.Finance;

namespace CocktailBar.Domain.Common.ValueObjects;

/// <summary>
/// Represents a base price with amount and currency.
/// </summary>
public class Price : ValueObject<Price>, IAddableValueObject<Price>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Price"/> class.
    /// </summary>
    /// <param name="amount">The amount of the price.</param>
    /// <param name="currency">The currency of the price.</param>
    internal Price(decimal amount, Currency currency)
    {
        ValidateAmount(amount);
        Amount = amount;
        Currency = currency;
    }
    
    private Price() {}

    /// <summary>
    /// Gets the amount of the price.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets the currency of the price.
    /// </summary>
    public Currency Currency { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="Price"/> class.
    /// </summary>
    /// <param name="amount">The amount of the price.</param>
    /// <param name="currency">The currency of the price.</param>
    /// <returns>A new <see cref="Price"/> instance.</returns>
    public static Price Create(decimal amount, Currency currency) 
        => new(amount, currency);

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Amount;
        yield return Currency;
    }

    /// <summary>
    /// Adds two price objects together.
    /// </summary>
    /// <param name="other">The price to add.</param>
    /// <returns>A new <see cref="Price"/> instance.</returns>
    /// <exception cref="DomainException">Thrown when the currencies don't match.</exception>
    public Price Add(Price other)
    {
        if (other.Currency != Currency) throw DomainException.For<Price>("Currencies don't match while adding prices.");
        return new Price(Amount + other.Amount, Currency);
    }

    /// <summary>
    /// Validates the given amount value.
    /// </summary>
    /// <param name="amount">The amount to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void ValidateAmount(decimal amount)
    {
        if (amount % 0.01m != 0) throw DomainException.For<Price>("Amount cannot have more than two decimal places.");
        if (amount < 0) throw DomainException.For<Price>("Amount cannot be a negative value.");
    }
}
