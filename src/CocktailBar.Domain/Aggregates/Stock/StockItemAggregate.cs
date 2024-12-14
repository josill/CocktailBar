// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Stock;

public readonly record struct StockItemId(Guid Value);

public class StockItemAggregate : Aggregate<StockItemId>
{
    private StockItemAggregate() {} // Private constructor for EF Core
    
    /// <summary>
    /// Initializes a new instance of the <see cref="StockItemAggregate"/> class.
    /// </summary>
    /// <param name="ingredientId">Unique identifier of the associated ingredient</param>
    /// <param name="stockOrderId">Unique identifier of the associated stock order</param>
    /// <param name="warehouseId">Unique identifier of the associated warehouse</param>
    private StockItemAggregate(IngredientId ingredientId, StockOrderId stockOrderId, WarehouseId warehouseId)
    {
        IngredientId = ingredientId;
        StockOrderId = stockOrderId;
        WarehouseId = warehouseId;
    }
    
    /// <summary>
    /// Gets the unique identifier of the ingredient associated with this stock item.
    /// </summary>
    public IngredientId IngredientId { get; }
    
    /// <summary>
    /// Gets the unique identifier of the order the item belongs to.
    /// </summary>
    public StockOrderId StockOrderId { get; }
    
    /// <summary>
    /// Gets the unique identifier of the warehouse where this stock item is located at.
    /// </summary>
    public WarehouseId WarehouseId { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="StockItemAggregate"/> class.
    /// </summary>
    /// <param name="ingredientId">Unique identifier of the associated ingredient</param>
    /// <param name="stockOrderId">Unique identifier of the associated stock order</param>
    /// <param name="warehouseId">Unique identifier of the associated warehouse</param>
    /// <returns>A new <see cref="StockItemAggregate"/> instance.</returns>
    public static StockItemAggregate Create(IngredientId ingredientId, StockOrderId stockOrderId, WarehouseId warehouseId)
        => new(ingredientId, stockOrderId, warehouseId);
}
