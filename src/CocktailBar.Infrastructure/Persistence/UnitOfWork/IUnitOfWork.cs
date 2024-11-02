// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Write;

namespace CocktailBar.Infrastructure.Persistence.UnitOfWork;

using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Read;

public interface IUnitOfWork : IAsyncDisposable
{
    Task BeginTransactionAsync();

    Task CommitAsync();

    Task RollbackAsync();

    ICocktailsReadContext CocktailsReadContext { get; }

    ICocktailsWriteContext CocktailsWriteContext { get; }
}
