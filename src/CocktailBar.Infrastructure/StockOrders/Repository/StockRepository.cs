// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.StockOrderAggregate.Entities;
using CocktailBar.Domain.StockOrderAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.StockOrders.Repository;

public class StockOrderRepository(IAppDbContext context) : Repository<StockOrder, StockOrderId>(context)
{
}
