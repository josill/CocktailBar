// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Infrastructure.Recipes.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Recipes.Context;

internal sealed class RecipeContext(DbContextOptions<RecipeContext> options) : DbContext(options), IRecipeContext
{
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new RecipeConfiguration().Configure(modelBuilder.Entity<Recipe>());
    }
}
