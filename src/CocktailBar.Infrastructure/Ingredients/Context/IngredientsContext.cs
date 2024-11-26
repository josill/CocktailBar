// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Infrastructure.Ingredients.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Ingredients.Context;

internal sealed class IngredientsContext(DbContextOptions<IngredientsContext> options) 
    : DbContext(options), IIngredientsContext
{
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new IngredientConfiguration().Configure(builder.Entity<Ingredient>());
    }
}
