// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Write;

internal sealed class IngredientWriteModelConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => IngredientId.From(value));
        
        builder.Property(x => x.StockItemId)
            .HasConversion(
                id => id.Value,
                value => StockItemId.From(value));
        
        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
