// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeixeiraSoftware.Finance;

namespace CocktailBar.Infrastructure.Common.Configurations.ValueObjects;

public class CurrencyConfiguration
{
    public void Configure(ComplexPropertyBuilder<Currency> builder)
    {
        builder.Property(x => x.Name);
        builder.Property(x => x.Sign);
        builder.Property(x => x.Symbol);
    }
}
