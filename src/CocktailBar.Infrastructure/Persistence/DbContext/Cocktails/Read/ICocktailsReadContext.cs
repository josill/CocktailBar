// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Read;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface ICocktailsReadContext : IDisposable
{
    // DbSets with read models
    DbSet<RecipeReadModel> Recipes { get; set; }

    DbSet<CocktailReadModel> Cocktails { get; set; }

    // Query-related members from DbContext
    DatabaseFacade Database { get; }
}
