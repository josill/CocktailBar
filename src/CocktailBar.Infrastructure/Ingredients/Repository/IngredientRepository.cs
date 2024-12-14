// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Application.Common.Interfaces.Repository;

namespace CocktailBar.Infrastructure.Ingredients.Repository;

public class IngredientRepository(IAppDbContext context) : Common.Repository.Repository(context), IIngredientRepository
{
}
