// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Stock;

public readonly record struct StockOrderId(Guid Value);

/// <summary>
/// Represents a stock order containing raw materials for the bars.
/// </summary>
public class StockOrderAggregate : Aggregate<StockOrderId>
{
    private readonly List<StockItem> _stockItems = [];

    private StockOrderAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="StockOrderAggregate"/> class.
    /// </summary>
    /// <param name="id">Unique identifier of the stock order.</param>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    /// <param name="stockItems">The stock items associated with the order.</param>
    private StockOrderAggregate(StockOrderId id, string orderNumber, StockOrderPrice price, DateTime orderedAtDate, DateTime orderArriveDate, List<StockItem>? stockItems = null) : base(id)
    {
        Validate(orderNumber, orderedAtDate, orderArriveDate);
        OrderNumber = orderNumber.Trim().ToLower();
        Price = price;
        OrderedAtDate = orderedAtDate;
        OrderArriveDate = orderArriveDate;
        if (stockItems is not null && stockItems.Count > 0) _stockItems = stockItems;
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
    public IEnumerable<StockItem> StockItems => _stockItems.AsReadOnly().ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="StockOrderAggregate"/> class.
    /// </summary>
    /// <param name="orderNumber">The number of the order.</param>
    /// <param name="price">The price of the order.</param>
    /// <param name="orderedAtDate">The date and time when the order was placed.</param>
    /// <param name="orderArriveDate">The date and time when the order arrived.</param>
    /// <param name="stockItems">The stock items associated with the order.</param>
    /// <returns>A new <see cref="StockOrderAggregate"/> instance.</returns>
    public static StockOrderAggregate Create(string orderNumber, StockOrderPrice price, DateTime orderedAtDate, DateTime orderArriveDate, List<StockItem>? stockItems = null)
    {
        var id = new StockOrderId(Guid.NewGuid());
        return new StockOrderAggregate(id, orderNumber, price, orderedAtDate, orderArriveDate, stockItems);
    }

    /// <summary>
    /// Adds a stock item to the order if it doesn't already exist.
    /// </summary>
    /// <param name="ingredientId">The ID of the ingredient to add.</param>
    /// <param name="warehouseId">The ID of the warehouse.</param>
    /// <exception cref="DomainException">Thrown when the stock item already exists in the order.</exception>
    public void AddStockItem(IngredientId ingredientId, WarehouseId warehouseId)
    {
        var stockItem = StockItem.Create(ingredientId, Id, warehouseId);
        if (_stockItems.Contains(stockItem))
            throw DomainException.For<StockOrderAggregate>("Stock item is already in the order.");

        _stockItems.Add(stockItem);
    }

    /// <summary>
    /// Removes a stock item from the order.
    /// </summary>
    /// <param name="ingredientId">The ID of the ingredient to add.</param>
    /// <param name="warehouseId">The ID of the warehouse.</param>
    /// <exception cref="DomainException">Thrown when the stock item doesn't exist in the order.</exception>
    public void RemoveStockItem(IngredientId ingredientId, WarehouseId warehouseId)
    {
        var stockItem = StockItem.Create(ingredientId, Id, warehouseId);
        if (!_stockItems.Contains(stockItem))
            throw DomainException.For<StockOrderAggregate>("Stock item does not exist in the order.");

        _stockItems.Remove(stockItem);
    }

    /// <summary>
    /// Validates the stock order number, order and arrive at date.
    /// </summary>
    /// <param name="orderNumber">The order number to validate.</param>
    /// <param name="orderedAtDate">The ordered at date to validate.</param>
    /// <param name="orderArriveDate">The order arrive date to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string orderNumber, DateTime orderedAtDate, DateTime orderArriveDate)
    {
        if (string.IsNullOrWhiteSpace(orderNumber)) throw DomainException.For<StockOrderAggregate>("Stock order number can not be empty.");
        if (orderedAtDate > DateTime.Now) throw DomainException.For<StockOrderAggregate>("Stock order ordered at date has to be in the past.");
        if (orderArriveDate < DateTime.Now) throw DomainException.For<StockOrderAggregate>("Stock order arrive arrive date has to be in the future.");
    }
}
