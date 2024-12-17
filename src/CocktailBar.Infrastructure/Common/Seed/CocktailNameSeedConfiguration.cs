using CocktailBar.Domain.Enumerations.Cocktail;
using CocktailBar.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class CocktailNameSeedConfiguration : IEntityTypeConfiguration<CocktailName>
{
    public void Configure(EntityTypeBuilder<CocktailName> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<CocktailName> GetSeedData()
    {
        return Enumeration.GetAll<CocktailName>();
    }
}
