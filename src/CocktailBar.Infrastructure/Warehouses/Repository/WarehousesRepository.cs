// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.WarehouseAggregate.Entities;
using CocktailBar.Domain.WarehouseAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.Warehouses.Repository;

public class WarehousesRepository(IAppDbContext context) : Repository<Warehouse, WarehouseId>(context)
{
}
