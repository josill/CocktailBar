// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.Recipes.Repository;

public class RecipeRepository(IAppDbContext context) : Repository<RecipeAggregate>(context)
{
}
