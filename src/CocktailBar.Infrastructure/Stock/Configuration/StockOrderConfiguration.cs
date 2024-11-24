// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockAggregate.Entities;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Stock.Configuration;

internal sealed class StockOrderConfiguration : IEntityTypeConfiguration<StockOrder>
{
    public void Configure(EntityTypeBuilder<StockOrder> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => StockOrderId.From(value))
            .IsRequired();

        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);

        // builder.ComplexProperty(x => x.Price, priceBuilder =>
        // {
        //     priceBuilder.Property(p => p.OrderPrice);
        //     priceBuilder.Property(p => p.ShippingPrice);
        //     priceBuilder.Property(p => p.Currency);
        // });
        
        builder.Property(x => x.OrderedAtDate)
            .IsRequired();
            
        builder.Property(x => x.OrderArriveDate)
            .IsRequired();
        
        
    }
}
