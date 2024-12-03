// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockOrderAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IStockOrdersContext : IDisposable
{ 
    DbSet<StockOrder> StockOrders { get; set; }
}
