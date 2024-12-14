// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Stock;

public readonly record struct StockOrderId(Guid Value);

public class StockOrder : Aggregate<StockOrderId>
{
    private readonly List<StockItemAggregate> _stockItems = new();
    
    private StockOrder() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="StockOrder"/> class.
    /// </summary>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    /// <param name="stockItems">The stock items associated with the order.</param>
    private StockOrder(string orderNumber, StockOrderPrice price, DateTime orderedAtDate, DateTime orderArriveDate, List<StockItemAggregate>? stockItems = null)
    {
        OrderNumber = orderNumber.Trim(); // TODO: toLower as well?
        Price = price;
        OrderedAtDate = orderedAtDate;
        OrderArriveDate = orderArriveDate;
        if (stockItems is not null) _stockItems = stockItems;
    }
    
    /// <summary>
    /// Gets the number of the order.
    /// </summary>
    public string OrderNumber { get; }
    
    /// <summary>
    /// Gets the price of the order.
    /// </summary>
    public StockOrderPrice Price { get; }
    
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
    public IEnumerable<StockItemAggregate> StockItems => _stockItems.AsReadOnly().ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="StockOrder"/> class.
    /// </summary>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    /// <param name="stockItems">The stock items associated with the order.</param>
    /// <returns>A new <see cref="StockOrder"/> instance.</returns>
    public static StockOrder Create(string orderNumber, StockOrderPrice price, DateTime orderedAtDate, DateTime orderArriveDate, List<StockItemAggregate>? stockItems = null)
        => new(orderNumber, price, orderedAtDate, orderArriveDate, stockItems);
    
    /// <summary>
    /// Adds a stock item to the order if it doesn't already exist.
    /// </summary>
    /// <param name="stockItemAggregate">The stock item to add.</param>
    /// <exception cref="DomainException">Thrown when the stock item already exists in the order.</exception>
    public void AddStockItem(StockItemAggregate stockItemAggregate)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItemAggregate));
        if (stockItemAlreadyExists) throw DomainException.For<StockOrder>("Stock item is already in the order.");

        _stockItems.Add(stockItemAggregate);
    }

    /// <summary>
    /// Removes a stock item from the order.
    /// </summary>
    /// <param name="stockItemAggregate">The stock item to remove.</param>
    /// <exception cref="DomainException">Thrown when the stock item doesn't exist in the order.</exception>
    public void RemoveStockItem(StockItemAggregate stockItemAggregate)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItemAggregate));
        if (stockItemAlreadyExists) throw DomainException.For<StockOrder>("Stock item not found in the order.");

        _stockItems.Remove(stockItemAggregate);
    }
}
