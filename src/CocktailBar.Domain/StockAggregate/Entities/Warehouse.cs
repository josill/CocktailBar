// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common;
using CocktailBar.Domain.Common.Errors;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

namespace CocktailBar.Domain.StockAggregate.Entities;

public class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<StockItem> _stockItems = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Warehouse"/> class.
    /// </summary>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">The stock items stored in the warehouse.</param>
    private Warehouse(string name, List<StockItem>? stockItems = null) : base(WarehouseId.New())
    {
        Name = name;
        if (stockItems is not null) _stockItems = stockItems;
    }
    
    private Warehouse() {}
    
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
    public List<StockItem> StockItems => _stockItems.ToList();

    /// <summary>
    /// Creates a new instance of the <see cref="Warehouse"/> class.
    /// </summary>
    /// <param name="name">The name of the warehouse.</param>
    /// <param name="stockItems">Optional initial list of stock items.</param>
    /// <returns>A new <see cref="Warehouse"/> instance.</returns>
    public static Warehouse Create(string name, List<StockItem>? stockItems = null)
        => new(name, stockItems);
    
    /// <summary>
    /// Adds a stock item to the warehouse if it doesn't already exist.
    /// </summary>
    /// <param name="stockItem">The stock item to add.</param>
    /// <exception cref="DomainException">Thrown when the stock item already exists in the warehouse.</exception>
    public void AddStockItem(StockItem stockItem)
    {
        var existingStockItem = _stockItems.Any(i => i.Equals(stockItem));
        DomainException.For<Warehouse>(existingStockItem, "Stock item is already in the warehouse.");

        _stockItems.Add(stockItem);
    }

    /// <summary>
    /// Removes a stock item from the warehouse.
    /// </summary>
    /// <param name="stockItem">The stock item to remove.</param>
    /// <exception cref="DomainException{Warehouse}">Thrown when the stock item doesn't exist in the warehouse.</exception>
    public void RemoveStockItem(StockItem stockItem)
    {
        var existingStockItem = _stockItems.FirstOrDefault(i => i.Equals(stockItem));
        DomainException.For<Warehouse>(existingStockItem == null, "Stock item not found in the warehouse.");

        _stockItems.Remove(stockItem);
    }
}
