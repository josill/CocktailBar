// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Infrastructure.Cocktails.Configuration;
using CocktailBar.Infrastructure.Ingredients.Configuration;
using CocktailBar.Infrastructure.Recipes.Configuration;
using CocktailBar.Infrastructure.StockItems.Configuration;
using CocktailBar.Infrastructure.StockOrders.Configuration;
using CocktailBar.Infrastructure.Warehouses.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<CocktailAggregate> Cocktails { get; set; }
    public DbSet<RecipeAggregate> Recipes { get; set; }
    public DbSet<IngredientAggregate> Ingredients { get; set; }
    public DbSet<StockOrder> StockOrders { get; set; }
    public DbSet<StockItemAggregate> StockItems { get; set; }
    public DbSet<WarehouseAggregate> Warehouses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<CocktailAggregate>());
        new RecipeConfiguration().Configure(modelBuilder.Entity<RecipeAggregate>());
        new IngredientConfiguration().Configure(modelBuilder.Entity<IngredientAggregate>());
        new StockOrderConfiguration().Configure(modelBuilder.Entity<StockOrder>());
        new StockItemConfiguration().Configure(modelBuilder.Entity<StockItemAggregate>());
        new WarehouseConfiguration().Configure(modelBuilder.Entity<WarehouseAggregate>());
        
        base.OnModelCreating(modelBuilder);
    }
}
