// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Context.Read;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Read;
using CocktailBar.Infrastructure.Cocktails.Configuration.Read;
using Microsoft.EntityFrameworkCore;

internal sealed class CocktailsReadContext(DbContextOptions<CocktailsReadContext> options)
    : DbContext(options), ICocktailsReadContext
{
    public DbSet<RecipeReadModel> Recipes { get; set; }

    public DbSet<CocktailReadModel> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsReadModelConfiguration().Configure(modelBuilder.Entity<CocktailReadModel>());
    }

    private static bool WriteConfigurationFilter(Type type) =>
        type.FullName?.Contains("Configurations.Read") ?? false;
}
