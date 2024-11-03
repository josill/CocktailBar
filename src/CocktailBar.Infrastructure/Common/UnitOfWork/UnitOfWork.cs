// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

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

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="cocktailsRepository">The repository for cocktail-related operations.</param>
    /// <param name="cocktailsReadContext">The read-only context for cocktail operations.</param>
    /// <param name="cocktailsWriteContext">The write-only context for cocktail operations.</param>
    public UnitOfWork(
        ICocktailsRepository cocktailsRepository,
        ICocktailsReadContext cocktailsReadContext,
        ICocktailsWriteContext cocktailsWriteContext)
    {
        Cocktails = cocktailsRepository;
        CocktailsReadContext = cocktailsReadContext;
        CocktailsWriteContext = cocktailsWriteContext;
    }

    /// <summary>
    /// Gets the repository for managing cocktail entities.
    /// Provides access to CRUD operations and specialized queries for cocktails.
    /// </summary>
    public ICocktailsRepository Cocktails { get; }

    /// <summary>
    /// Gets the read-only database context for cocktail-related operations.
    /// </summary>
    public ICocktailsReadContext CocktailsReadContext { get; }

    /// <summary>
    /// Gets the write-only database context for cocktail-related operations.
    /// </summary>
    public ICocktailsWriteContext CocktailsWriteContext { get; }

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
        if (_transaction is not null)
        {
            await CocktailsWriteContext.Database.RollbackTransactionAsync();
            _transaction.Dispose();
            _transaction = null;
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
            if (_transaction is not null)
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
