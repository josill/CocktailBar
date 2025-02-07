// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using System.Data.Common;
using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Application.Common.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace CocktailBar.Infrastructure.SeedWork.UnitOfWork;

/// <summary>
/// Implements the Unit of Work pattern to manage database transactions and context access.
/// Provides coordinated data access and transaction management for the CocktailBar application.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private DbTransaction? _transaction;
    private bool _disposed;
    private bool _hasActiveTransaction;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    #pragma warning disable SA1611
    public UnitOfWork(
        ICocktailRepository cocktailsRepository,
        IRecipeRepository recipesRepository,
        IIngredientRepository ingredientsRepository,
        IStockOrderRepository stockOrdersRepository,
        IStockItemRepository stockItemsRepository,
        IWarehouseRepository warehousesRepository,
        IAppDbContext appDbContext)
    {
        Cocktails = cocktailsRepository;
        Recipes = recipesRepository;
        Ingredients = ingredientsRepository;
        StockOrders = stockOrdersRepository;
        StockItems = stockItemsRepository;
        Warehouses = warehousesRepository;
        Context = appDbContext;
    }
    #pragma warning restore SA1611

    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// </summary>
    public ICocktailRepository Cocktails { get; }

    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// </summary>
    public IRecipeRepository Recipes { get; }

    /// <summary>
    /// Gets the repository for manging ingredient entities.
    /// </summary>
    public IIngredientRepository Ingredients { get; }

    /// <summary>
    /// Gets the repository for managing stock order entities.
    /// </summary>
    public IStockOrderRepository StockOrders { get; }

    /// <summary>
    /// Gets the repository for managing stock item entities.
    /// </summary>
    public IStockItemRepository StockItems { get; }

    /// <summary>
    /// Gets the repository for managing warehouse entities.
    /// </summary>
    public IWarehouseRepository Warehouses { get; }

    public IAppDbContext Context { get; }

    /// <summary>
    /// Begins a new database transaction asynchronously.
    /// Initializes the transaction on the write context for maintaining data consistency.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task BeginTransactionAsync()
    {
        _transaction = (await Context.Database
                .BeginTransactionAsync())
            .GetDbTransaction();
    }

    /// <summary>
    /// Commits the current transaction asynchronously.
    /// Saves changes to the database and commits the transaction if one exists.
    /// If an error occurs during the commit, automatically rolls back the transaction.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Rethrows any exception that occurs during the commit process.</exception>
    public async Task CommitAsync()
    {
        try
        {
            await Context.SaveChangesAsync();

            if (_transaction is not null)
            {
                await Context.Database.CommitTransactionAsync();
                _hasActiveTransaction = false;
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// Rolls back the current transaction asynchronously if one exists.
    /// Disposes of the transaction after rollback.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RollbackAsync()
    {
        if (_transaction is not null && _hasActiveTransaction)
        {
            await Context.Database.RollbackTransactionAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
            _hasActiveTransaction = false;
        }
    }

    /// <summary>
    /// Asynchronously releases resources used by the UnitOfWork instance.
    /// Rolls back any active transaction and disposes of both read and write contexts.
    /// </summary>
    /// <returns>A ValueTask representing the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (_transaction is not null && _hasActiveTransaction)
            {
                await RollbackAsync();
            }

            Context.Dispose();

            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }
}
