using CocktailBar.Domain.Enumerations.Ingredient;
using CocktailBar.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class IngredientNameSeedConfiguration : IEntityTypeConfiguration<IngredientName>
{
    public void Configure(EntityTypeBuilder<IngredientName> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<IngredientName> GetSeedData()
    {
        return Enumeration.GetAll<IngredientName>();
    }
}
