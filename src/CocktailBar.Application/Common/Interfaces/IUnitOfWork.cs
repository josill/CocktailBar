// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.RecipeAggregate.Entities;
using CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;

namespace CocktailBar.Application.Common.Interfaces;

/// <summary>
/// Defines a contract for managing database transactions and context access in the CocktailBar application.
/// Implements the Unit of Work pattern to maintain data consistency across multiple operations.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// </summary>
    IRepository<Cocktail, CocktailId> Cocktails { get; }
    
    /// <summary>
    /// Gets the repository for managing recipe entities.
    /// </summary>
    IRepository<Recipe, RecipeId> Recipes { get; }

    /// <summary>
    /// Begins a new database transaction asynchronously.
    /// This should be called before performing a series of related database operations.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task BeginTransactionAsync();

    /// <summary>
    /// Commits the current transaction asynchronously, saving all changes to the database.
    /// This should be called after all related operations have completed successfully.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CommitAsync();

    /// <summary>
    /// Rolls back the current transaction asynchronously, reverting any changes made.
    /// This should be called when an error occurs during the transaction to maintain data consistency.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RollbackAsync();
}
