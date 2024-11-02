// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class CocktailWriteModelConfiguration : IEntityTypeConfiguration<Cocktail>
{
    public void Configure(EntityTypeBuilder<Cocktail> builder)
    {
        builder.HasKey(c => c.Id);

        // TODO: Configure relation to recipe id
    }
}
