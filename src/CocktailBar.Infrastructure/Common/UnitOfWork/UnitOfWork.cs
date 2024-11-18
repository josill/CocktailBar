// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

namespace CocktailBar.Infrastructure.Common.UnitOfWork;

using System.Data.Common;
using CocktailBar.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

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
    /// <param name="cocktailsRepository">The repository for cocktail-related operations.</param>
    /// <param name="recipesRepository">The repository for recipe-related operations.</param>
    /// <param name="cocktailsReadContext">The read-only context for cocktail operations.</param>
    /// <param name="cocktailsWriteContext">The write-only context for cocktail operations.</param>
    public UnitOfWork(
        IRepository<Cocktail, CocktailId> cocktailsRepository,
        IRepository<Recipe, RecipeId> recipesRepository,
        ICocktailsReadContext cocktailsReadContext,
        ICocktailsWriteContext cocktailsWriteContext)
    {
        Cocktails = cocktailsRepository;
        Recipes = recipesRepository;
        CocktailsReadContext = cocktailsReadContext;
        CocktailsWriteContext = cocktailsWriteContext;
    }

    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// </summary>
    public IRepository<Cocktail, CocktailId> Cocktails { get; }
    
    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// </summary>
    public IRepository<Recipe, RecipeId> Recipes { get; }

    /// <summary>
    /// Gets the read-only database context for cocktail-related operations.
    /// </summary>
    private ICocktailsReadContext CocktailsReadContext { get; }

    /// <summary>
    /// Gets the write-only database context for cocktail-related operations.
    /// </summary>
    private ICocktailsWriteContext CocktailsWriteContext { get; }

    /// <summary>
    /// Begins a new database transaction asynchronously.
    /// Initializes the transaction on the write context for maintaining data consistency.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task BeginTransactionAsync()
    {
        _transaction = (await CocktailsWriteContext.Database
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
            await CocktailsWriteContext.SaveChangesAsync();

            if (_transaction is not null)
            {
                await CocktailsWriteContext.Database.CommitTransactionAsync();
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
            await CocktailsWriteContext.Database.RollbackTransactionAsync();
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

            CocktailsReadContext.Dispose();
            CocktailsWriteContext.Dispose();

            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }
}
