// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Application.Common.Interfaces.Repository;

namespace CocktailBar.Infrastructure.StockOrders.Repository;

public class StockOrderRepository(IAppDbContext context) : Common.Repository.Repository(context), IStockOrderRepository
{
}
