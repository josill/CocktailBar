// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

internal sealed class RelationalReadDbContext : DbContext
    // , IUnitOfWork
{
    public DbSet<RecipeReadModel> Recipes { get; set; }

    public DbSet<CocktailReadModel> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(RelationalReadDbContext).Assembly,
            WriteConfigurationFilter);
    }

    private static bool WriteConfigurationFilter(Type type) =>
        type.FullName?.Contains("Configurations.Read") ?? false;
}
