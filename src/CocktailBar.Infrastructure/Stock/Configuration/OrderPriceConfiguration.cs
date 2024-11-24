// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Stock.Configuration;

public class OrderPriceConfiguration
{
    public void Configure(ComplexPropertyBuilder<OrderPrice> builder)
    {
        builder.Property(x => x.OrderCost);
        builder.Property(x => x.ShippingCost);
    }
}
