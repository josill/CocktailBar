// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Ingredients.Configuration;

internal sealed class IngredientConfiguration : IEntityTypeConfiguration<IngredientAggregate>
{
    public void Configure(EntityTypeBuilder<IngredientAggregate> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new IngredientId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.StockItemId)
            .HasConversion(
                id => id.Value,
                value => new StockItemId(value));
        
        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
