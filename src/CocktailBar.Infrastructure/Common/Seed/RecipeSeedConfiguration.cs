// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class RecipeSeedConfiguration : IEntityTypeConfiguration<RecipeAggregate>
{
    public void Configure(EntityTypeBuilder<RecipeAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static List<RecipeAggregate> GetSeedData()
    {
        return
        [
        ];
    }
}
