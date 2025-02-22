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
public class WarehouseAggregate : Aggregate<WarehouseId>
{
    private readonly List<StockItem> _stockItems = [];

    private WarehouseAggregate() {} // Private constructor for EF Core

    /// <summary>
    /// Initializes a new instance of the <see cref="WarehouseAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the warehouse.</param>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">The stock items stored in the warehouse.</param>
    private WarehouseAggregate(WarehouseId id, string name, List<StockItem>? stockItems = null) : base(id)
    {
        Validate(name);
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
    public IEnumerable<StockItem> StockItems => _stockItems.AsReadOnly().ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="WarehouseAggregate"/> class.
    /// </summary>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">Optional initial list of stock items.</param>
    /// <returns>A new <see cref="WarehouseAggregate"/> instance.</returns>
    public static WarehouseAggregate Create(string name, List<StockItem>? stockItems = null)
    {
        var id = new WarehouseId(Guid.NewGuid());
        return new WarehouseAggregate(id, name, stockItems);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="WarehouseAggregate"/> class.
    /// </summary>
    /// <param name="id">The id of the warehouse.</param>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">Optional initial list of stock items.</param>
    /// <returns>A new <see cref="WarehouseAggregate"/> instance.</returns>
    /// <remarks>This method should only be used for seeding data.</remarks>
    public static WarehouseAggregate Create(WarehouseId id, string name, List<StockItem>? stockItems = null)
        => new(id, name, stockItems);

    /// <summary>
    /// Adds a stock item to the warehouse if it doesn't already exist.
    /// </summary>
    /// <param name="stockItem">The stock item to add.</param>
    /// <exception cref="DomainException">Thrown when the stock item already exists in the warehouse.</exception>
    public void AddStockItem(StockItem stockItem)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItem));
        if (stockItemAlreadyExists) throw DomainException.For<WarehouseAggregate>("Stock item is already in the warehouse.");

        _stockItems.Add(stockItem);
    }

    /// <summary>
    /// Removes a stock item from the warehouse.
    /// </summary>
    /// <param name="stockItem">The stock item to remove.</param>
    /// <exception cref="DomainException">Thrown when the stock item doesn't exist in the warehouse.</exception>
    public void RemoveStockItem(StockItem stockItem)
    {
        var stockItemAlreadyExists = _stockItems.Any(i => i.Equals(stockItem));
        if (stockItemAlreadyExists) DomainException.For<WarehouseAggregate>("Stock item not found in the warehouse.");

        _stockItems.Remove(stockItem);
    }

    /// <summary>
    /// Validates the warehouse name.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<WarehouseAggregate>("Warehouse name can not be empty.");
    }
}
