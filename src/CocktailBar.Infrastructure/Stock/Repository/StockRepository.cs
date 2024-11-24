// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.StockAggregate.Entities;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Stock.Repository;

public class StockRepository(IAppDbContext context) : IRepository<StockItem, StockItemId>
{
    public async Task<StockItem?> GetByIdAsync(StockItemId id)
    {
        return await context.StockItems
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<StockItem>> GetAllAsync()
    {
        return await context.StockItems.ToListAsync();
    }

    public async Task AddAsync(StockItem entity)
    {
        await context.StockItems.AddAsync(entity);
    }

    public void Update(StockItem entity)
    {
        context.StockItems.Update(entity);
    }

    public void Delete(StockItem entity)
    {
        context.StockItems.Remove(entity);
    }
}
