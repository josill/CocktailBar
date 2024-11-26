// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IWarehousesContext : IDisposable
{
    DbSet<Warehouse> Warehouses { get; set; }
}
