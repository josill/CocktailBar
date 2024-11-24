// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class RecipeWriteModelConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => RecipeId.From(value))
            .IsRequired();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Instructions)
            .IsRequired();

        builder.HasMany(x => x.Ingredients)
            .WithMany()
            .UsingEntity(entityBuilder => entityBuilder.ToTable("RecipeIngredients"));
    }
}
