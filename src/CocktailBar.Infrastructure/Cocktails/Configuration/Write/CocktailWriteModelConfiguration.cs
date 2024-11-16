// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the database schema and mapping for the Cocktail domain entity.
/// This configuration is specifically for the write-side of the CQRS pattern.
/// </summary>
internal sealed class CocktailsWriteModelConfiguration : IEntityTypeConfiguration<Cocktail>
{
    /// <summary>
    /// Configures the entity mapping for the Cocktail entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Cocktail> builder)
    {
        builder.ToTable("Cocktails");

        builder.HasKey(c => c.Id);

        builder.Property(o => o.Id)
            .HasConversion(
                id => id.Value,
                value => CocktailId.From(value))
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasColumnType("varchar");

        builder.Property(c => c.RecipeId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => RecipeId.From(value));

        builder.HasIndex(c => c.Name);
    }
}
