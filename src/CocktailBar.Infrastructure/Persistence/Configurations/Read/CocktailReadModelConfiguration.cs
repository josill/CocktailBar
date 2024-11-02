// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations.Read;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class CocktailReadModelConfiguration : IEntityTypeConfiguration<CocktailReadModel>
{
    public void Configure(EntityTypeBuilder<CocktailReadModel> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
