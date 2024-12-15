// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Stock;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IStockItemsContext : IDisposable
{
    DbSet<StockItemAggregate> StockItems { get; }
}
