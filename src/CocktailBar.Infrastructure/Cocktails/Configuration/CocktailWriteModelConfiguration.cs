// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Cocktails.Configuration;

internal sealed class CocktailsWriteModelConfiguration : IEntityTypeConfiguration<Cocktail>
{
    public void Configure(EntityTypeBuilder<Cocktail> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => CocktailId.From(value))
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
                value => RecipeId.From(value));

        builder.HasIndex(x => x.Name);
    }
}