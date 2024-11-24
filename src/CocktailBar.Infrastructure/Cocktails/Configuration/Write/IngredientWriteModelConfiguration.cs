// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Write;

internal sealed class IngredientWriteModelConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        // builder.ToTable("Ingredients");
        //
        // builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => IngredientId.From(value));
        
        builder.Property(x => x.StockItemId)
            .HasConversion(
                id => id.Value,
                value => StockItemId.From(value));
        
        builder.ComplexProperty(x => x.Amount, ingredientBuilder =>
        {
            ingredientBuilder.Property(a => a.Unit);
            ingredientBuilder.Property(a => a.Value);
        });
    }
}
