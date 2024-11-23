// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.StockAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CocktailBar.Application.Common.Interfaces;

public interface IStockContext : IDisposable
{
    DbSet<StockOrder> StockOrders { get; set; }

    DbSet<StockItem> StockItems { get; set; }
    
    DbSet<Warehouse> Warehouses { get; set; }

    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;
}
