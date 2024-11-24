// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common;
using CocktailBar.Domain.Common.Errors;
using CocktailBar.Domain.StockAggregate.Enums;

namespace CocktailBar.Domain.StockAggregate.ValueObjects;

/// <summary>
/// Represents a price with order price, shipping price and currency.
/// </summary>
public class Price : ValueObject<Price>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Price"/> class.
    /// </summary>
    /// <param name="orderPrice">The base price of the order.</param>
    /// <param name="shippingPrice">The shipping price of the order.</param>
    /// <param name="currency">The currency of the price.</param>
    /// <remarks>
    /// This constructor is private to enforce creation through the <see cref="Create"/> method.
    /// </remarks>
    private Price(decimal orderPrice, decimal shippingPrice, Currency currency)
    {
        Validate(orderPrice, shippingPrice);
        OrderPrice = orderPrice;
        ShippingPrice = shippingPrice;
        Currency = currency;
    }
    
    private Price() {}

    /// <summary>
    /// Gets the base price of the order.
    /// </summary>
    public decimal OrderPrice { get; }

    /// <summary>
    /// Gets the shipping price of the order.
    /// </summary>
    public decimal ShippingPrice { get; }

    /// <summary>
    /// Gets the currency of the price.
    /// </summary>
    public Currency Currency { get; }

    /// <summary>
    /// Gets the total price (order price + shipping price).
    /// </summary>
    public decimal TotalPrice => OrderPrice + ShippingPrice;

    /// <summary>
    /// Creates a new instance of the <see cref="Price"/> class.
    /// </summary>
    /// <param name="orderPrice">The base price of the order.</param>
    /// <param name="shippingPrice">The shipping price of the order.</param>
    /// <param name="currency">The currency of the price.</param>
    /// <returns>A new <see cref="Price"/> instance.</returns>
    public static Price Create(decimal orderPrice, decimal shippingPrice, Currency currency) 
        => new(orderPrice, shippingPrice, currency);

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return OrderPrice;
        yield return ShippingPrice;
        yield return Currency;
    }

    /// <summary>
    /// Validates the given price values.
    /// </summary>
    /// <param name="orderPrice">The order price to validate.</param>
    /// <param name="shippingPrice">The shipping price to validate.</param>
    /// <exception cref="DomainException{Price}">Thrown when validation fails.</exception>
    private static void Validate(decimal orderPrice, decimal shippingPrice)
    {
        DomainException.For<Price>(orderPrice % 0.01m != 0, "Order price cannot have more than two decimal places.");
        DomainException.For<Price>(shippingPrice % 0.01m != 0, "Shipping price cannot have more than two decimal places.");
        DomainException.For<Price>(orderPrice < 0, "Order price cannot be a negative value.");
        DomainException.For<Price>(shippingPrice < 0, "Shipping price cannot be a negative value.");
    }
}
