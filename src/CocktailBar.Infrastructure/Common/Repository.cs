// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common;

/// <summary>
/// Base implementation of the generic repository pattern that works with Entity Framework Core.
/// </summary>
/// <typeparam name="TEntity">The type of entity this repository handles. Must be a reference type.</typeparam>
/// <typeparam name="TId">The type of entity id this repository handles. Must be a reference type.</typeparam>
public abstract class Repository<TEntity, TId>(IAppDbContext context) : IRepository<TEntity, TId>
    where TEntity : class
    where TId : class
{
    /// <summary>
    /// The database context used by this repository.
    /// </summary>
    protected readonly IAppDbContext Context = context ?? throw new ArgumentNullException(nameof(context));

    /// <summary>
    /// The Entity Framework Core DbSet for the entity type.
    /// </summary>
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        DbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}
