// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.IngredientAggregate.Entities;
using CocktailBar.Domain.RecipeAggregate.Entities;
using CocktailBar.Domain.StockItemAggregate.Entities;
using CocktailBar.Domain.StockOrderAggregate.Entities;
using CocktailBar.Domain.WarehouseAggregate.Entities;
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
    
    public DbSet<Cocktail> Cocktails { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<StockOrder> StockOrders { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<Cocktail>());
        new RecipeConfiguration().Configure(modelBuilder.Entity<Recipe>());
        new IngredientConfiguration().Configure(modelBuilder.Entity<Ingredient>());
        new StockOrderConfiguration().Configure(modelBuilder.Entity<StockOrder>());
        new StockItemConfiguration().Configure(modelBuilder.Entity<StockItem>());
        new WarehouseConfiguration().Configure(modelBuilder.Entity<Warehouse>());
        
        base.OnModelCreating(modelBuilder);
    }
}
