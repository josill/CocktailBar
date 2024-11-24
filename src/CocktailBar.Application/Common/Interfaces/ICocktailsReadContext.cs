// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

using CocktailBar.Domain.CocktailAggregate.Read;
using Microsoft.EntityFrameworkCore;

public interface ICocktailsReadContext : IDisposable
{
    DbSet<RecipeReadModel> Recipes { get; set; }

    DbSet<CocktailReadModel> Cocktails { get; set; }
}
