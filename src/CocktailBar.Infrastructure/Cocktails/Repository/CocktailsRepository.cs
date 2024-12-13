// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.Cocktails.Repository;

using CocktailBar.Domain.CocktailAggregate.Entities;

public class CocktailsRepository(IAppDbContext context) : Repository<Cocktail>(context)
{
}
