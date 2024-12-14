// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common.Repository;

/// <summary>
/// Base implementation of the generic repository pattern that works with Entity Framework Core.
/// </summary>
public abstract class Repository(IAppDbContext context) : IRepository
{
    /// <summary>
    /// The database context used by this repository.
    /// </summary>
    protected readonly IAppDbContext Context = context;

    public virtual async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await Context.Set<T>().AddAsync(entity);
    }

    public virtual void Update<T>(T entity) where T : class
    {
        Context.Set<T>().Update(entity);
    }

    public virtual void Delete<T>(T entity) where T : class
    {
        Context.Set<T>().Remove(entity);
    }
}
