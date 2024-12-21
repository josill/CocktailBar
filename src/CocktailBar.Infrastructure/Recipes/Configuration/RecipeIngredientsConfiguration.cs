using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Recipes.Configuration;

internal sealed class RecipeIngredientsConfiguration : IEntityTypeConfiguration<RecipeIngredientsAggregate>
{
    public void Configure(EntityTypeBuilder<RecipeIngredientsAggregate> builder)
    {
        builder.ToTable("RecipeIngredients");

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new RecipeIngredientsAggregateId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne<RecipeAggregate>()
            .WithMany()
            .HasForeignKey(x => x.RecipeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<IngredientAggregate>()
            .WithMany()
            .HasForeignKey(x => x.IngredientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
