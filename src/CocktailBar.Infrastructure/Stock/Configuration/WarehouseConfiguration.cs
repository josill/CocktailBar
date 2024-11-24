// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockAggregate.Entities;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Stock.Configuration;

internal sealed class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        // builder.ToTable("Warehouses");
        //
        // builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => WarehouseId.From(value))
            .IsRequired();
        
        // builder.Property(x => x.Name)
        //     .IsRequired()
        //     .HasMaxLength(100);
    }
}
