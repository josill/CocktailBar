// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

namespace CocktailBar.Domain.StockAggregate.Entities;

public class StockItem : AggregateRoot<StockItemId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StockItem"/> class.
    /// </summary>
    /// <param name="ingredientId">Unique identifier of the associated ingredient</param>
    /// <param name="stockOrderId">Unique identifier of the associated stock order</param>
    /// <param name="warehouseId">Unique identifier of the associated warehouse</param>
    private StockItem(IngredientId ingredientId, StockOrderId stockOrderId, WarehouseId warehouseId) : base(StockItemId.New())
    {
        IngredientId = ingredientId;
        StockOrderId = stockOrderId;
        WarehouseId = warehouseId;
    }
    
    private StockItem() {}
    
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
    /// Creates a new instance of the <see cref="StockItem"/> class.
    /// </summary>
    /// <param name="ingredientId">Unique identifier of the associated ingredient</param>
    /// <param name="stockOrderId">Unique identifier of the associated stock order</param>
    /// <param name="warehouseId">Unique identifier of the associated warehouse</param>
    /// <returns>A new <see cref="StockItem"/> instance.</returns>
    public static StockItem Create(IngredientId ingredientId, StockOrderId stockOrderId, WarehouseId warehouseId)
        => new(ingredientId, stockOrderId, warehouseId);
}
