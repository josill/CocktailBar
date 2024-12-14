// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.Warehouses.Repository;

public class WarehousesRepository(IAppDbContext context) : Repository<WarehouseAggregate>(context)
{
}
