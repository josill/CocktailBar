// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Infrastructure.Common;
using CocktailBar.Infrastructure.Common.Repository;

namespace CocktailBar.Infrastructure.Ingredients.Repository;

public class IngredientRepository(IAppDbContext context) : Repository<IngredientAggregate>(context)
{
}
