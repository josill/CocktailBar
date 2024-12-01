// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.IngredientAggregate.ValueObjects.Ids;
using CocktailBar.Domain.StockItemAggregate.Entities;
using CocktailBar.Domain.StockItemAggregate.ValueObjects.Ids;
using CocktailBar.Domain.StockOrderAggregate.ValueObjects.Ids;
using CocktailBar.Domain.WarehouseAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.StockItems.Configuration;

internal sealed class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
{
    
    public void Configure(EntityTypeBuilder<StockItem> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => StockItemId.From(value))
            .IsRequired();
        
        builder.Property(x => x.IngredientId)
            .HasConversion(
                id => id.Value,
                value => IngredientId.From(value))
            .IsRequired();

        builder.Property(x => x.StockOrderId)
            .HasConversion(
                id => id.Value,
                value => StockOrderId.From(value))
            .IsRequired();

        builder.Property(x => x.WarehouseId)
            .HasConversion(
                id => id.Value,
                value => WarehouseId.From(value))
            .IsRequired();
    }
}
