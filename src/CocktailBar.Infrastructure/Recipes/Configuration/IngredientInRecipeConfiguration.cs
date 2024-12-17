using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Infrastructure.Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Recipes.Configuration;

internal sealed class IngredientInRecipeConfiguration : IEntityTypeConfiguration<IngredientInRecipeAggregate>
{
    public void Configure(EntityTypeBuilder<IngredientInRecipeAggregate> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new IngredientInRecipeAggregateId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();

        new AmountConfiguration().Configure(builder.ComplexProperty(x => x.Amount));
    }
}
