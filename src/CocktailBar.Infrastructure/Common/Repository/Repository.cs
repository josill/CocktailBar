// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common.Repository;

/// <summary>
/// Base implementation of the repository pattern for aggregate roots using Entity Framework Core.
/// </summary>
public abstract class Repository(IAppDbContext context) : IRepository
{
    /// <summary>
    /// The database context used by this repository.
    /// </summary>
    private readonly IAppDbContext _context = context;

    /// <summary>
    /// Retrieves an aggregate by its primary key.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="id">The primary key value.</param>
    /// <returns>The aggregate if found; otherwise, null.</returns>
    public virtual async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    /// <summary>
    /// Retrieves all aggregates of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <returns>A collection of all aggregates.</returns>
    public virtual async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Adds a new aggregate to the context.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="entity">The aggregate to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
    }

    /// <summary>
    /// Updates an existing aggregate in the context.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="entity">The aggregate to update.</param>
    public virtual void Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
    }

    /// <summary>
    /// Marks an aggregate for deletion in the context.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="entity">The aggregate to delete.</param>
    public virtual void Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
    }
}
