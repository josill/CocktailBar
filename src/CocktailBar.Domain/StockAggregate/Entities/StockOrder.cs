// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

namespace CocktailBar.Domain.StockAggregate.Entities;

public class StockOrder : AggregateRoot<StockOrderId>
{
    private readonly List<StockItem> _stockItems = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="StockOrder"/> class.
    /// </summary>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    private StockOrder(string orderNumber, Price price, DateTime orderedAtDate, DateTime orderArriveDate) : base(
        StockOrderId.New())
    {
        OrderNumber = orderNumber;
        Price = price;
        OrderedAtDate = orderedAtDate;
        OrderArriveDate = orderArriveDate;
    }
    
    private StockOrder() {}
    
    /// <summary>
    /// Gets the number of the order.
    /// </summary>
    public string OrderNumber { get; }
    
    /// <summary>
    /// Gets the price of the order.
    /// </summary>
    public Price Price { get; }
    
    /// <summary>
    /// Gets the date when the order was placed.
    /// </summary>
    public DateTime OrderedAtDate { get; }
    
    /// <summary>
    /// Gets the date when the order arrived.
    /// </summary>
    public DateTime OrderArriveDate { get; }
    
    /// <summary>
    /// Gets a read-only list of stock items in the order.
    /// </summary>
    /// <remarks>
    /// Returns a copy of the internal list to prevent external modifications.
    /// </remarks>
    public List<StockItem> StockItems => _stockItems.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="StockOrder"/> class.
    /// </summary>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    /// <returns>A new <see cref="StockOrder"/> instance.</returns>
    public static StockOrder Create(string orderNumber, Price price, DateTime orderedAtDate, DateTime orderArriveDate)
        => new();
}
