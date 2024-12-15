using CocktailBar.Domain.Aggregates.Cocktail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class CocktailSeedConfiguration : IEntityTypeConfiguration<CocktailAggregate>
{
    public void Configure(EntityTypeBuilder<CocktailAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<CocktailAggregate> GetSeedData()
    {
        return
        [

        ];
    }
}
