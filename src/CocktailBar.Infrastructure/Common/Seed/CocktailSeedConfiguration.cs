// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Cocktail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class CocktailSeedConfiguration : IEntityTypeConfiguration<CocktailAggregate>
{
    public void Configure(EntityTypeBuilder<CocktailAggregate> builder)
    {
        builder.HasData()
    }

    private static List<CocktailAggregate> GetCocktailAggregateSeedData()
    {
        return
        [

        ];
    }
}
