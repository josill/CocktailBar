// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface ICocktailsWriteContext : IDisposable
{
    DbSet<Recipe> Recipes { get; set; }

    DbSet<Cocktail> Cocktails { get; set; }

    // Essential DbContext members needed for write operations
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;
}
