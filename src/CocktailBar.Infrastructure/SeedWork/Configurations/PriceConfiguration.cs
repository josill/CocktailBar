// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.SeedWork.Configurations;

public class PriceConfiguration
{
    public void Configure(ComplexPropertyBuilder<Price> builder)
    {
        builder.Property(x => x.Amount);
        builder.Property(x => x.Currency);
    }
}
