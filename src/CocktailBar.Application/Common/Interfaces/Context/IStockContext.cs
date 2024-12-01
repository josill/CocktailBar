// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockItemAggregate.Entities;
using CocktailBar.Domain.StockOrderAggregate.Entities;
using CocktailBar.Domain.WarehouseAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IStockContext : IDisposable
{
    DbSet<StockOrder> StockOrders { get; set; }

    DbSet<StockItem> StockItems { get; set; }
    
    DbSet<Warehouse> Warehouses { get; set; }
}
