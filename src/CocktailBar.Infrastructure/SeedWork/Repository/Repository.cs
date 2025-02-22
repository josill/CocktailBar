// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Application.Common.Interfaces.Querying;
using CocktailBar.Infrastructure.SeedWork.Queryable;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.SeedWork.Repository;

public abstract class Repository(IAppDbContext context) : IRepository
{
    public virtual async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<IPaginatedList<T>> GetPagedListAsync<T>(int page, int pageSize) where T : class
    {
        return await context.Set<T>().ToPaginatedListAsync(page, pageSize);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await context.Set<T>().AddAsync(entity);
    }

    public virtual void Update<T>(T entity) where T : class
    {
        context.Set<T>().Update(entity);
    }

    public virtual void Delete<T>(T entity) where T : class
    {
        context.Set<T>().Remove(entity);
    }
}
