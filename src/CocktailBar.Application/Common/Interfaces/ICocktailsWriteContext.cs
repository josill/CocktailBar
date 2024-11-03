// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
/// Defines a contract for write operations in the CocktailBar application.
/// This interface represents the write side of the CQRS pattern, focusing on command operations.
/// </summary>
public interface ICocktailsWriteContext : IDisposable
{
    /// <summary>
    /// Gets or sets the entity set for Recipe domain entities.
    /// Provides write access for creating, updating, and deleting recipes.
    /// </summary>
    DbSet<Recipe> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the entity set for Cocktail domain entities.
    /// Provides write access for creating, updating, and deleting cocktails.
    /// </summary>
    DbSet<Cocktail> Cocktails { get; set; }

    /// <summary>
    /// Gets the database facade, providing access to database-level operations.
    /// Used for managing database connections and transactions in write operations.
    /// </summary>
    DatabaseFacade Database { get; }

    /// <summary>
    /// Asynchronously saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the save operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of TEntity.
    /// Provides a generic way to access entity sets not explicitly defined as properties.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which a set should be returned.</typeparam>
    /// <returns>A set for the given entity type.</returns>
    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;
}