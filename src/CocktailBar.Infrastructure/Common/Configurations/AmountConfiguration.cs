// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects;
using CocktailBar.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Configurations;

public class AmountConfiguration
{
    public void Configure(ComplexPropertyBuilder<Amount> builder)
    {
        builder.Property(x => x.Unit);
        builder.Property(x => x.Value);
    }
}
