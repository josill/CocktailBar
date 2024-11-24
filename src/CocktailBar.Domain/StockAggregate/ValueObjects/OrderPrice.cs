// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.ValueObjects;

namespace CocktailBar.Domain.StockAggregate.ValueObjects;

/// <summary>
/// Represents an order price with base price, shipping price and currency.
/// </summary>
public class OrderPrice 
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    private OrderPrice(Price orderCost, Price shippingCost) 
    {
        OrderCost = orderCost;
        ShippingCost = shippingCost;
    }

    /// <summary>
    /// Gets the base amount of the order.
    /// </summary>
    public Price OrderCost { get; }

    /// <summary>
    /// Gets the shipping amount of the order.
    /// </summary>
    public Price ShippingCost { get; }

    /// <summary>
    /// Gets the total cost of the order
    /// </summary>
    public virtual Price TotalCost => OrderCost + ShippingCost;

    /// <summary>
    /// Creates a new instance of the <see cref="OrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    /// <returns>A new <see cref="OrderPrice"/> instance.</returns>
    public static OrderPrice Create(Price orderCost, Price shippingCost) 
        => new(orderCost, shippingCost);
}
