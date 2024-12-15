using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;
using CocktailBar.Infrastructure.Common.Seed.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class IngredientSeedConfiguration : IEntityTypeConfiguration<IngredientAggregate>
{
    public void Configure(EntityTypeBuilder<IngredientAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<IngredientAggregate> GetSeedData()
    {
        return
        [
            IngredientAggregate.Create("Grey Goose Vodka", Amount.Create(50, WeightUnit.Ml), StockItemIds.GreyGooseVodka),
            IngredientAggregate.Create("Belvedere Vodka", Amount.Create(50, WeightUnit.Ml), StockItemIds.BelvedereVodka),
            IngredientAggregate.Create("Absolut Vodka", Amount.Create(50, WeightUnit.Ml), StockItemIds.AbsolutVodka),
            IngredientAggregate.Create("Stolichnaya Vodka", Amount.Create(50, WeightUnit.Ml), StockItemIds.StolichnayaVodka),
            IngredientAggregate.Create("Tanqueray Gin", Amount.Create(50, WeightUnit.Ml), StockItemIds.TanquerayGin),
            IngredientAggregate.Create("Beefeater Gin", Amount.Create(50, WeightUnit.Ml), StockItemIds.BeefeaterGin),
            IngredientAggregate.Create("Plymouth Gin", Amount.Create(50, WeightUnit.Ml), StockItemIds.PlymouthGin),
            IngredientAggregate.Create("Hendrick's Gin", Amount.Create(50, WeightUnit.Ml), StockItemIds.HendricksGin),
            IngredientAggregate.Create("Maker's Mark", Amount.Create(50, WeightUnit.Ml), StockItemIds.MakersMark),
            IngredientAggregate.Create("Buffalo Trace", Amount.Create(50, WeightUnit.Ml), StockItemIds.BuffaloTrace),
            IngredientAggregate.Create("Rittenhouse Rye", Amount.Create(50, WeightUnit.Ml), StockItemIds.RittenhouseRye),
            IngredientAggregate.Create("Bulleit Rye", Amount.Create(50, WeightUnit.Ml), StockItemIds.BulleitRye),
            IngredientAggregate.Create("Amaretto", Amount.Create(30, WeightUnit.Ml), StockItemIds.Amaretto),
            IngredientAggregate.Create("Baileys Irish Cream", Amount.Create(30, WeightUnit.Ml), StockItemIds.BaileysIrishCream),
            IngredientAggregate.Create("Campari", Amount.Create(30, WeightUnit.Ml), StockItemIds.Campari),
            IngredientAggregate.Create("St. Germain", Amount.Create(20, WeightUnit.Ml), StockItemIds.StGermain),
            IngredientAggregate.Create("Fresh Lime Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LimeJuice),
            IngredientAggregate.Create("Fresh Lemon Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LemonJuice),
            IngredientAggregate.Create("Orange Juice", Amount.Create(60, WeightUnit.Ml), StockItemIds.OrangeJuice),
            IngredientAggregate.Create("Cranberry Juice", Amount.Create(60, WeightUnit.Ml), StockItemIds.CranberryJuice),
            IngredientAggregate.Create("Mint Leaves", Amount.Create(6, WeightUnit.Piece), StockItemIds.MintLeaves),
            IngredientAggregate.Create("Lime Wedge", Amount.Create(1, WeightUnit.Piece), StockItemIds.LimeWedge),
            IngredientAggregate.Create("Lemon Twist", Amount.Create(1, WeightUnit.Piece), StockItemIds.LemonTwist),
            IngredientAggregate.Create("Orange Peel", Amount.Create(1, WeightUnit.Piece), StockItemIds.OrangePeel),
            IngredientAggregate.Create("Maraschino Cherry", Amount.Create(1, WeightUnit.Piece), StockItemIds.MaraschinoCherries),
            IngredientAggregate.Create("Olive", Amount.Create(1, WeightUnit.Piece), StockItemIds.Olives)
        ];
    }
}
