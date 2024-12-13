// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.StockOrderAggregate.ValueObjects;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.StockOrders.Configuration;

internal sealed class OrderPriceConfiguration
{
    public void Configure(ComplexPropertyBuilder<OrderPrice> builder)
    {
        new PriceConfiguration().Configure(builder.ComplexProperty(x => x.OrderCost));
        new PriceConfiguration().Configure(builder.ComplexProperty(x => x.ShippingCost));
    }
}
