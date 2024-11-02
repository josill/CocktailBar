// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Write;

namespace CocktailBar.Infrastructure.Persistence.UnitOfWork;

using System.Data;
using System.Data.Common;
using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Read;
using Microsoft.EntityFrameworkCore.Storage;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ICocktailsReadContext _cocktailsReadContext;
    private readonly ICocktailsWriteContext _cocktailsWriteContext;
    private DbTransaction? _transaction;
    private bool _disposed;

    public ICocktailsReadContext CocktailsReadContext => _cocktailsReadContext;

    public ICocktailsWriteContext CocktailsWriteContext => _cocktailsWriteContext;

    public UnitOfWork(
        ICocktailsReadContext cocktailsReadContext,
        ICocktailsWriteContext cocktailsWriteContext)
    {
        _cocktailsReadContext = cocktailsReadContext;
        _cocktailsWriteContext = cocktailsWriteContext;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = (await _cocktailsWriteContext.Database
                .BeginTransactionAsync())
            .GetDbTransaction();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _cocktailsWriteContext.SaveChangesAsync();

            if (_transaction is not null)
            {
                await _cocktailsWriteContext.Database.CommitTransactionAsync();
            }
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _cocktailsWriteContext.Database.RollbackTransactionAsync();
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (_transaction is not null)
            {
                await RollbackAsync();
            }

            _cocktailsReadContext.Dispose();
            _cocktailsWriteContext.Dispose();

            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }
}
