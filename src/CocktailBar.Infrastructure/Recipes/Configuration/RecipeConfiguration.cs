// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Recipes.Configuration;

internal sealed class RecipeConfiguration : IEntityTypeConfiguration<RecipeAggregate>
{
    public void Configure(EntityTypeBuilder<RecipeAggregate> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new RecipeId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Instructions)
            .IsRequired();
        
        builder.HasMany(x => x.Ingredients)
            .WithMany(x => x.Recipes)
            .UsingEntity(j => j.ToTable("RecipeIngredients"));
    }
}
