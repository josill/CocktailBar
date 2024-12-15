// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;
using CocktailBar.Infrastructure.Common.Seed.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Seed;

public class RecipeSeedConfiguration : IEntityTypeConfiguration<CocktailAggregate>
{
    public void Configure(EntityTypeBuilder<CocktailAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static List<RecipeAggregate> GetSeedData()
    {
        return
        [
            RecipeAggregate.Create(
                "Classic Martini",
                "1. Fill mixing glass with ice\n2. Add gin/vodka and vermouth\n3. Stir for 30 seconds\n4. Strain into chilled martini glass\n5. Garnish with olive or lemon twist",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Tanqueray Gin", Amount.Create(75, WeightUnit.Ml), StockItemIds.TanquerayGin),
                    IngredientAggregate.Create("Dry Vermouth", Amount.Create(15, WeightUnit.Ml), StockItemIds.DryVermouth),
                    IngredientAggregate.Create("Olive", Amount.Create(1, WeightUnit.Piece), StockItemIds.Olives),
                }
            ),
            RecipeAggregate.Create(
                "Manhattan",
                "1. Fill mixing glass with ice\n2. Add whiskey, vermouth, and bitters\n3. Stir for 30 seconds\n4. Strain into chilled coupe glass\n5. Garnish with cherry",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Rittenhouse Rye", Amount.Create(60, WeightUnit.Ml), StockItemIds.RittenhouseRye),
                    IngredientAggregate.Create("Sweet Vermouth", Amount.Create(30, WeightUnit.Ml), StockItemIds.SweetVermouth),
                    IngredientAggregate.Create("Angostura Bitters", Amount.Create(2, WeightUnit.Piece), StockItemIds.AngosturaBitters),
                    IngredientAggregate.Create("Maraschino Cherry", Amount.Create(1, WeightUnit.Piece), StockItemIds.MaraschinoCherries),
                }
            ),
            RecipeAggregate.Create(
                "Margarita",
                "1. If desired, salt rim of glass\n2. Fill shaker with ice\n3. Add all ingredients\n4. Shake vigorously for 10-15 seconds\n5. Strain into glass over fresh ice",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Blanco Tequila", Amount.Create(60, WeightUnit.Ml), StockItemIds.BlancoTequila),
                    IngredientAggregate.Create("Fresh Lime Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LimeJuice),
                    IngredientAggregate.Create("Simple Syrup", Amount.Create(20, WeightUnit.Ml), StockItemIds.SimpleSyrup),
                    IngredientAggregate.Create("Lime Wedge", Amount.Create(1, WeightUnit.Piece), StockItemIds.LimeWedge),
                }
            ),
            RecipeAggregate.Create(
                "Mojito",
                "1. In shaker, muddle mint leaves with simple syrup\n2. Add rum and lime juice\n3. Shake with ice\n4. Strain into highball glass over fresh ice\n5. Top with club soda\n6. Garnish with mint sprig",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("White Rum", Amount.Create(60, WeightUnit.Ml), StockItemIds.WhiteRum),
                    IngredientAggregate.Create("Fresh Lime Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LimeJuice),
                    IngredientAggregate.Create("Simple Syrup", Amount.Create(20, WeightUnit.Ml), StockItemIds.SimpleSyrup),
                    IngredientAggregate.Create("Mint Leaves", Amount.Create(8, WeightUnit.Piece), StockItemIds.MintLeaves),
                }
            ),
            RecipeAggregate.Create(
                "Old Fashioned",
                "1. Place sugar cube in glass and saturate with bitters\n2. Add small splash of water and muddle\n3. Fill glass with ice cubes\n4. Add bourbon\n5. Garnish with orange peel",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Buffalo Trace Bourbon", Amount.Create(60, WeightUnit.Ml), StockItemIds.BuffaloTrace),
                    IngredientAggregate.Create("Angostura Bitters", Amount.Create(2, WeightUnit.Piece), StockItemIds.AngosturaBitters),
                    IngredientAggregate.Create("Simple Syrup", Amount.Create(10, WeightUnit.Ml), StockItemIds.SimpleSyrup),
                    IngredientAggregate.Create("Orange Peel", Amount.Create(1, WeightUnit.Piece), StockItemIds.OrangePeel),
                }
            ),
            RecipeAggregate.Create(
                "Negroni",
                "1. Fill mixing glass with ice\n2. Add all ingredients\n3. Stir well\n4. Strain into rocks glass filled with ice\n5. Garnish with orange peel",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Tanqueray Gin", Amount.Create(30, WeightUnit.Ml), StockItemIds.TanquerayGin),
                    IngredientAggregate.Create("Sweet Vermouth", Amount.Create(30, WeightUnit.Ml), StockItemIds.SweetVermouth),
                    IngredientAggregate.Create("Campari", Amount.Create(30, WeightUnit.Ml), StockItemIds.Campari),
                    IngredientAggregate.Create("Orange Peel", Amount.Create(1, WeightUnit.Piece), StockItemIds.OrangePeel),
                }
            ),
            RecipeAggregate.Create(
                "Daiquiri",
                "1. Add all ingredients to shaker with ice\n2. Shake vigorously\n3. Double strain into chilled coupe glass\n4. Garnish with lime wheel if desired",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("White Rum", Amount.Create(60, WeightUnit.Ml), StockItemIds.WhiteRum),
                    IngredientAggregate.Create("Fresh Lime Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LimeJuice),
                    IngredientAggregate.Create("Simple Syrup", Amount.Create(20, WeightUnit.Ml), StockItemIds.SimpleSyrup),
                    IngredientAggregate.Create("Lime Wedge", Amount.Create(1, WeightUnit.Piece), StockItemIds.LimeWedge),
                }
            ),
            RecipeAggregate.Create(
                "Moscow Mule",
                "1. Fill copper mug with ice\n2. Add vodka and lime juice\n3. Top with ginger beer\n4. Garnish with lime wedge",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Grey Goose Vodka", Amount.Create(60, WeightUnit.Ml), StockItemIds.GreyGooseVodka),
                    IngredientAggregate.Create("Fresh Lime Juice", Amount.Create(15, WeightUnit.Ml), StockItemIds.LimeJuice),
                    IngredientAggregate.Create("Ginger Beer", Amount.Create(120, WeightUnit.Ml), StockItemIds.GingerBeer),
                    IngredientAggregate.Create("Lime Wedge", Amount.Create(1, WeightUnit.Piece), StockItemIds.LimeWedge),
                }
            ),
            RecipeAggregate.Create(
                "Whiskey Sour",
                "1. Add all ingredients to shaker with ice\n2. Shake vigorously\n3. Strain into rocks glass over fresh ice\n4. Garnish with orange slice and cherry",
                new List<IngredientAggregate>
                {
                    IngredientAggregate.Create("Buffalo Trace Bourbon", Amount.Create(60, WeightUnit.Ml), StockItemIds.BuffaloTrace),
                    IngredientAggregate.Create("Fresh Lemon Juice", Amount.Create(30, WeightUnit.Ml), StockItemIds.LemonJuice),
                    IngredientAggregate.Create("Simple Syrup", Amount.Create(20, WeightUnit.Ml), StockItemIds.SimpleSyrup),
                    IngredientAggregate.Create("Orange Peel", Amount.Create(1, WeightUnit.Piece), StockItemIds.OrangePeel),
                    IngredientAggregate.Create("Maraschino Cherry", Amount.Create(1, WeightUnit.Piece), StockItemIds.MaraschinoCherries),
                }
            )
        ];
    }
}
