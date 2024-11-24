// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.StockAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Common.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<StockOrder> StockOrders { get; set; }
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Cocktail> Cocktails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<Cocktail>());
        // new RecipeWriteModelConfiguration().Configure(modelBuilder.Entity<Recipe>());
        // new IngredientWriteModelConfiguration().Configure(modelBuilder.Entity<Ingredient>());
        // new StockOrderConfiguration().Configure(modelBuilder.Entity<StockOrder>());
        // new StockItemConfiguration().Configure(modelBuilder.Entity<StockItem>());
        // new WarehouseConfiguration().Configure(modelBuilder.Entity<Warehouse>());
    }
}
