// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Cocktails.Configuration;

internal sealed class CocktailsWriteModelConfiguration : IEntityTypeConfiguration<CocktailAggregate>
{
    public void Configure(EntityTypeBuilder<CocktailAggregate> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new CocktailId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.RecipeId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => new RecipeId(value));

        builder.HasIndex(x => x.Name);
    }
}
