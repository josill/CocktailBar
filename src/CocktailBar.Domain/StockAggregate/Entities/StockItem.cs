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
    /// <param name="stockItemId"></param>
    private StockItem(StockItemId? stockItemId = null) : base(stockItemId ?? StockItemId.New())
    {
        
    }
    
    private StockItem() {}
    
    /// <summary>
    /// Gets the unique identifier of the ingredient associated with this stock item.
    /// </summary>
    public IngredientId IngredientId { get; }
    
    /// <summary>
    /// Gets the unique identifier of the warehouse where this stock item is located at.
    /// </summary>
    public WarehouseId WarehouseId { get; }
    
    /// <summary>
    /// Gets the unique identifier of the order the item belongs to.
    /// </summary>
    public StockOrderId StockOrderId { get; }
    
    public static StockItem Create() {}
    
    public static StockItem From() {}
    
    private static void Validatre() {}
}
