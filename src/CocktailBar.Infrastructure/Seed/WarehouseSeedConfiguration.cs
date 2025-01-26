using CocktailBar.Domain.Aggregates.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Seed;

public class WarehouseSeedConfiguration : IEntityTypeConfiguration<WarehouseAggregate>
{
    public void Configure(EntityTypeBuilder<WarehouseAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<WarehouseAggregate> GetSeedData()
    {
        return [WarehouseAggregate.Create(new WarehouseId(Guid.Parse("030edea6-0054-46f5-b3aa-ae2a37ef8662")), "Ladu")];
    }
}
