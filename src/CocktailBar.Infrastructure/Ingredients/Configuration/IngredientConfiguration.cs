// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.IngredientAggregate.Entities;
using CocktailBar.Domain.IngredientAggregate.ValueObjects.Ids;
using CocktailBar.Domain.StockItemAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Ingredients.Configuration;

internal sealed class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new IngredientId(value));
        
        builder.Property(x => x.StockItemId)
            .HasConversion(
                id => id.Value,
                value => new StockItemId(value));
        
        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
