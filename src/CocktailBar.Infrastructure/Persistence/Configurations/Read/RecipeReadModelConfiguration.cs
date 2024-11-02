// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations.Read;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class RecipeReadModelConfiguration : IEntityTypeConfiguration<RecipeReadModel>
{
    public void Configure(EntityTypeBuilder<RecipeReadModel> builder)
    {
        builder.HasKey(r => r.Id);
    }
}
