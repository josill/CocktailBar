// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.StockOrders.Configuration;

internal sealed class StockOrderConfiguration : IEntityTypeConfiguration<StockOrder>
{
    public void Configure(EntityTypeBuilder<StockOrder> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new StockOrderId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.OrderedAtDate)
            .IsRequired();
            
        builder.Property(x => x.OrderArriveDate)
            .IsRequired();
        
        new OrderPriceConfiguration().Configure(builder.ComplexProperty(x => x.Price));
    }
}
