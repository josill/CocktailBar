// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.StockAggregate.Entities;
using CocktailBar.Infrastructure.Stock.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Stock.Context;

public sealed class StockContext : DbContext, IStockContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options)
    {
    }
    
    public DbSet<StockOrder> StockOrders { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new StockOrderConfiguration().Configure(modelBuilder.Entity<StockOrder>());
        new StockItemConfiguration().Configure(modelBuilder.Entity<StockItem>());
        new WarehouseConfiguration().Configure(modelBuilder.Entity<Warehouse>());
    }
}
