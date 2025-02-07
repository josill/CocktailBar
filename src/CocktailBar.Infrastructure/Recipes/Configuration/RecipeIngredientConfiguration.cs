using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Infrastructure.SeedWork.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Recipes.Configuration;

internal sealed class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("RecipeIngredients");

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new RecipeIngredientId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.RecipeId)
            .HasConversion(
                id => id.Value,
                value => new RecipeId(value))
            .IsRequired();

        builder.Property(x => x.IngredientId)
            .HasConversion(
                id => id.Value,
                value => new IngredientId(value))
            .IsRequired();

        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
