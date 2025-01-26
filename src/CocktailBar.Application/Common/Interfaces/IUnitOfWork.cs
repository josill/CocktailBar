// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Repository;

namespace CocktailBar.Application.Common.Interfaces;

/// <summary>
/// Defines a contract for managing database transactions and context access in the CocktailBar application.
/// Implements the Unit of Work pattern to maintain data consistency across multiple operations.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Gets the repository for managing cocktail aggregates.
    /// </summary>
    ICocktailRepository Cocktails { get; }

    /// <summary>
    /// Gets the repository for managing recipe aggregates.
    /// </summary>
    IRecipeRepository Recipes { get; }

    /// <summary>
    /// Gets the repository for manging ingredient aggergates.
    /// </summary>
    IIngredientRepository Ingredients { get; }

    /// <summary>
    /// Gets the repository for managing stock order aggregates.
    /// </summary>
    IStockOrderRepository StockOrders { get; }

    /// <summary>
    /// Gets the repository for managing stock items aggregates.
    /// </summary>
    IStockItemRepository StockItems { get; }

    /// <summary>
    /// Gets the repository for managing warehouse aggregates.
    /// </summary>
    IWarehouseRepository Warehouses { get; }

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
