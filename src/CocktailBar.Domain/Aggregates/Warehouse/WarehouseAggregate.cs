// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Warehouse;

public readonly record struct WarehouseId(Guid Value);

/// <summary>
/// Represents a warehouse where the stock is kept.
/// </summary>
public class WarehouseAggregate : AggregateRoot<WarehouseId>
{
    private readonly List<StockItemAggregate> _stockItems = new();

    private WarehouseAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="WarehouseAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">The stock items stored in the warehouse.</param>
    private WarehouseAggregate(string name, List<StockItemAggregate>? stockItems = null)
    {
        Name = name.Trim();
        if (stockItems is not null) _stockItems = stockItems;
    }

    /// <summary>
    /// Gets the name of the warehouse.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a read-only list of stock items in the warehouse.
    /// </summary>
    /// <remarks>
    /// Returns a copy of the internal list to prevent external modifications.
    /// </remarks>
    public List<StockItemAggregate> StockItems => _stockItems.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="WarehouseAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">Optional initial list of stock items.</param>
    /// <returns>A new <see cref="WarehouseAggregate"/> instance.</returns>
    public static WarehouseAggregate Create(string name, List<StockItemAggregate>? stockItems = null)
        => new(name, stockItems);

    /// <summary>
    /// Adds a stock item to the warehouse if it doesn't already exist.
    /// </summary>
    /// <param name="stockItemAggregate">The stock item to add.</param>
    /// <exception cref="DomainException">Thrown when the stock item already exists in the warehouse.</exception>
    public void AddStockItem(StockItemAggregate stockItemAggregate)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItemAggregate));
        if (stockItemAlreadyExists) throw DomainException.For<WarehouseAggregate>("Stock item is already in the warehouse.");

        _stockItems.Add(stockItemAggregate);
    }

    /// <summary>
    /// Removes a stock item from the warehouse.
    /// </summary>
    /// <param name="stockItemAggregate">The stock item to remove.</param>
    /// <exception cref="DomainException">Thrown when the stock item doesn't exist in the warehouse.</exception>
    public void RemoveStockItem(StockItemAggregate stockItemAggregate)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItemAggregate));
        if (stockItemAlreadyExists) DomainException.For<WarehouseAggregate>("Stock item not found in the warehouse.");

        _stockItems.Remove(stockItemAggregate);
    }
}
