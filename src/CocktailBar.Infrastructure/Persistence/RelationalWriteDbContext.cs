// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;

public class RelationalWriteDbContext : DbContext
    // , IUnitOfWork
{
    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<Cocktail> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(RelationalWriteDbContext).Assembly,
            WriteConfigurationFilter);
    }

    private static bool WriteConfigurationFilter(Type type) =>
        type.FullName?.Contains("Configurations.Write") ?? false;
}
