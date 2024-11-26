// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.StockAggregate.Entities;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;

namespace CocktailBar.Infrastructure.Warehouses.Repository;

public class WarehousesRepository(IAppDbContext context) : Repository<Warehouse, WarehouseId>(context)
{
}
