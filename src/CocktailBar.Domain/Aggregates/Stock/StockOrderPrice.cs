// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;
using CocktailBar.Domain.ValueObjects;
using CocktailBar.Domain.ValueObjects.Interfaces;

namespace CocktailBar.Domain.Aggregates.Stock;

/// <summary>
/// Represents a stock order price with base price, shipping price and currency.
/// </summary>
public class StockOrderPrice : ValueObject<StockOrderPrice>, IArithmeticValueObject<StockOrderPrice>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StockOrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    private StockOrderPrice(Price orderCost, Price shippingCost)
    {
        Validate(orderCost, shippingCost);
        OrderCost = orderCost;
        ShippingCost = shippingCost;
    }

    private StockOrderPrice() {}

    /// <summary>
    /// Gets the base amount of the order.
    /// </summary>
    public Price OrderCost { get; }

    /// <summary>
    /// Gets the shipping amount of the order.
    /// </summary>
    public Price ShippingCost { get; }

    /// <summary>
    /// Gets the total cost of the order.
    /// </summary>
    public Price TotalCost => OrderCost + ShippingCost;

    /// <summary>
    /// Creates a new instance of the <see cref="StockOrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    /// <returns>A new <see cref="StockOrderPrice"/> instance.</returns>
    public static StockOrderPrice Create(Price orderCost, Price shippingCost)
        => new(orderCost, shippingCost);

    /// <summary>
    /// Adds two order price objects together.
    /// </summary>
    /// <param name="other">The price to add.</param>
    /// <returns>A new <see cref="StockOrderPrice"/> instance.</returns>
    /// <exception cref="DomainException">Thrown when the currencies don't match.</exception>
    public StockOrderPrice Add(StockOrderPrice other)
    {
        if (other.OrderCost.Currency != OrderCost.Currency) throw DomainException.For<StockOrderPrice>("Order cost currencies don't match while adding order prices.");
        if (other.ShippingCost.Currency != ShippingCost.Currency) throw DomainException.For<StockOrderPrice>("Shipping cost currencies don't match while adding order prices.");

        return new StockOrderPrice(OrderCost + other.OrderCost, ShippingCost + other.ShippingCost);
    }

    /// <summary>
    /// Subtracts two order items from each other.
    /// </summary>
    /// <param name="other">The price to subtract.</param>
    /// <returns>A new <see cref="StockOrderPrice"/> instance.</returns>
    /// <exception cref="DomainException">Thrown when the currencies don't match.</exception>
    public StockOrderPrice Subtract(StockOrderPrice other)
    {
        if (other.OrderCost.Currency != OrderCost.Currency) throw DomainException.For<StockOrderPrice>("Order cost currencies don't match while adding order prices.");
        if (other.ShippingCost.Currency != ShippingCost.Currency) throw DomainException.For<StockOrderPrice>("Shipping cost currencies don't match while adding order prices.");

        return new StockOrderPrice(OrderCost - other.OrderCost, ShippingCost - other.ShippingCost);
    }

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return OrderCost;
        yield return ShippingCost;
    }

    /// <summary>
    /// Validates the order and shipping costs.
    /// </summary>
    /// <param name="orderCost">The order cost to validate.</param>
    /// <param name="shippingCost">The shipping cost to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(Price orderCost, Price shippingCost)
    {
        if (orderCost.Currency != shippingCost.Currency) throw DomainException.For<StockOrderPrice>("Order cost and shipping cost must have the same currency.");
    }
}
