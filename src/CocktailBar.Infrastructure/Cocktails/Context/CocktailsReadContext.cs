// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Read;
using CocktailBar.Infrastructure.Cocktails.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Cocktails.Context;

internal sealed class CocktailsReadContext(DbContextOptions<CocktailsReadContext> options)
    : DbContext(options), ICocktailsReadContext
{
    public DbSet<RecipeReadModel> Recipes { get; set; }

    public DbSet<CocktailReadModel> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsReadModelConfiguration().Configure(modelBuilder.Entity<CocktailReadModel>());
    }
}
