// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.StockItemAggregate.Entities;
using CocktailBar.Domain.StockItemAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.StockItems.Repository;

public class StockItemsRepository(IAppDbContext context) : Repository<StockItem>(context)
{
}
