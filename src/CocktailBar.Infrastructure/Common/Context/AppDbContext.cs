// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;
using CocktailBar.Infrastructure.Cocktails.Configuration;
using CocktailBar.Infrastructure.Ingredients.Configuration;
using CocktailBar.Infrastructure.Recipes.Configuration;
using CocktailBar.Infrastructure.Seed;
using CocktailBar.Infrastructure.StockItems.Configuration;
using CocktailBar.Infrastructure.StockOrders.Configuration;
using CocktailBar.Infrastructure.Warehouses.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<CocktailAggregate> Cocktails { get; init; }

    public DbSet<RecipeAggregate> Recipes { get; init; }

    public DbSet<IngredientAggregate> Ingredients { get; init; }

    public DbSet<StockOrderAggregate> StockOrders { get; init; }

    public DbSet<StockItemAggregate> StockItems { get; init; }

    public DbSet<WarehouseAggregate> Warehouses { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyAggregatesConfiguration(modelBuilder);
        ApplySeedConfiguration(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ApplyAggregatesConfiguration(ModelBuilder modelBuilder)
    {
        new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<CocktailAggregate>());
        new RecipeConfiguration().Configure(modelBuilder.Entity<RecipeAggregate>());
        new IngredientConfiguration().Configure(modelBuilder.Entity<IngredientAggregate>());
        new RecipeIngredientConfiguration().Configure(modelBuilder.Entity<RecipeIngredientAggregate>());
        new StockOrderConfiguration().Configure(modelBuilder.Entity<StockOrderAggregate>());
        new StockItemConfiguration().Configure(modelBuilder.Entity<StockItemAggregate>());
        new WarehouseConfiguration().Configure(modelBuilder.Entity<WarehouseAggregate>());
    }

    private static void ApplySeedConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RecipeSeedConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientSeedConfiguration());

        // Complex properties are currently not supported in seeding. See https://github.com/dotnet/efcore/issues/31254 for more information.
        // modelBuilder.ApplyConfiguration(new RecipeIngredientsSeedConfiguration());
    }
}
