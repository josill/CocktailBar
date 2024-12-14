// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Application.Common.Interfaces.Repository;

namespace CocktailBar.Infrastructure.Cocktails.Repository;

public class CocktailsRepository(IAppDbContext context) : Common.Repository.Repository(context), ICocktailRepository
{
}
