// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common;

namespace CocktailBar.Infrastructure.Recipes.Repository;

public class RecipeRepository(IAppDbContext context) : Repository<Recipe, RecipeId>(context)
{
}
