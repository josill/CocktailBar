// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using System.ComponentModel.DataAnnotations.Schema;
using CocktailBar.Domain.Common.Base.Interfaces;
using CocktailBar.Domain.Common.Errors;
using CocktailBar.Domain.Common.ValueObjects;

namespace CocktailBar.Domain.StockAggregate.ValueObjects;

/// <summary>
/// Represents an order price with base price, shipping price and currency.
/// </summary>
public class OrderPrice : ValueObject<OrderPrice>, IAddableValueObject<OrderPrice>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    private OrderPrice(Price orderCost, Price shippingCost)
    {
        Validate(orderCost, shippingCost);
        OrderCost = orderCost;
        ShippingCost = shippingCost;
    }
    
    private OrderPrice() {}

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
    public Price TotalCost => OrderCost + ShippingCost;

    /// <summary>
    /// Creates a new instance of the <see cref="OrderPrice"/> class.
    /// </summary>
    /// <param name="orderCost">The base cost of the order.</param>
    /// <param name="shippingCost">The shipping cost of the order.</param>
    /// <returns>A new <see cref="OrderPrice"/> instance.</returns>
    public static OrderPrice Create(Price orderCost, Price shippingCost) 
        => new(orderCost, shippingCost);
    
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
    /// Adds two order price objects together.
    /// </summary>
    /// <param name="other">The price to add.</param>
    /// <returns>A new <see cref="OrderPrice"/> instance.</returns>
    /// <exception cref="DomainException{OrderPrice}">Thrown when the currencies don't match.</exception>
    public OrderPrice Add(OrderPrice other)
    {
        DomainException.For<OrderPrice>(other.OrderCost.Currency != OrderCost.Currency,
            "Order cost currencies don't match while adding order prices.");
        DomainException.For<OrderPrice>(other.ShippingCost.Currency != ShippingCost.Currency,
            "Shipping cost currencies don't match while adding order prices.");
        
        return new OrderPrice(OrderCost + other.OrderCost, ShippingCost + other.ShippingCost);
    }
    
    /// <summary>
    /// Validates the order and shipping costs.
    /// </summary>
    /// <param name="orderCost">The order cost to validate.</param>
    /// <param name="shippingCost">The shipping cost to validate.</param>
    /// <exception cref="DomainException{OrderPrice}">Thrown when validation fails.</exception>
    private static void Validate(Price orderCost, Price shippingCost)
    {
        DomainException.For<OrderPrice>(orderCost.Currency != shippingCost.Currency, 
            "Order cost and shipping cost must have the same currency.");
    }
}
