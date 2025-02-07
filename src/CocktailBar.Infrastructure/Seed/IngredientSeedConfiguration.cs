using CocktailBar.Domain.Aggregates.Ingredient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Seed;

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
            // Base Spirits - Vodka
            IngredientAggregate.Create(IngredientIds.GreyGooseVodka, "Grey Goose Vodka"),
            IngredientAggregate.Create(IngredientIds.BelvedereVodka, "Belvedere Vodka"),
            IngredientAggregate.Create(IngredientIds.AbsolutVodka, "Absolut Vodka"),
            IngredientAggregate.Create(IngredientIds.StolichnayaVodka, "Stolichnaya Vodka"),
            IngredientAggregate.Create(IngredientIds.CitrusVodka, "Citrus Vodka"),
            IngredientAggregate.Create(IngredientIds.VanillaVodka, "Vanilla Vodka"),

            // // Base Spirits - Gin
            // IngredientAggregate.Create(IngredientIds.TanquerayGin, "Tanqueray Gin"),
            // IngredientAggregate.Create(IngredientIds.BeefeaterGin, "Beefeater Gin"),
            // IngredientAggregate.Create(IngredientIds.PlymouthGin, "Plymouth Gin"),
            // IngredientAggregate.Create(IngredientIds.HendricksGin, "Hendrick's Gin"),
            //
            // // Base Spirits - Whiskey
            // IngredientAggregate.Create(IngredientIds.MakersMark, "Maker's Mark Bourbon"),
            // IngredientAggregate.Create(IngredientIds.BuffaloTrace, "Buffalo Trace Bourbon"),
            // IngredientAggregate.Create(IngredientIds.RittenhouseRye, "Rittenhouse Rye"),
            // IngredientAggregate.Create(IngredientIds.BulleitRye, "Bulleit Rye"),
            // IngredientAggregate.Create(IngredientIds.BlendedScotch, "Blended Scotch"),
            // IngredientAggregate.Create(IngredientIds.SingleMaltScotch, "Single Malt Scotch"),
            // IngredientAggregate.Create(IngredientIds.IrishWhiskey, "Irish Whiskey"),
            // IngredientAggregate.Create(IngredientIds.JapaneseWhisky, "Japanese Whisky"),
            //
            // // Base Spirits - Other
            // IngredientAggregate.Create(IngredientIds.Pisco, "Pisco"),
            // IngredientAggregate.Create(IngredientIds.Cognac, "Cognac"),
            // IngredientAggregate.Create(IngredientIds.Absinthe, "Absinthe"),
            //
            // // Base Spirits - Rum
            // IngredientAggregate.Create(IngredientIds.WhiteRum, "White Rum"),
            // IngredientAggregate.Create(IngredientIds.GoldRum, "Gold Rum"),
            // IngredientAggregate.Create(IngredientIds.DarkRum, "Dark Rum"),
            // IngredientAggregate.Create(IngredientIds.SpicedRum, "Spiced Rum"),
            // IngredientAggregate.Create(IngredientIds.OverproofRum, "Overproof Rum"),
            // IngredientAggregate.Create(IngredientIds.CoconutRum, "Coconut Rum"),
            //
            // // Base Spirits - Tequila
            // IngredientAggregate.Create(IngredientIds.BlancoTequila, "Blanco Tequila"),
            // IngredientAggregate.Create(IngredientIds.ReposadoTequila, "Reposado Tequila"),
            // IngredientAggregate.Create(IngredientIds.AnejoTequila, "Añejo Tequila"),
            // IngredientAggregate.Create(IngredientIds.Mezcal, "Mezcal"),
            //
            // // Liqueurs & Cordials
            // IngredientAggregate.Create(IngredientIds.Amaretto, "Amaretto"),
            // IngredientAggregate.Create(IngredientIds.BaileysIrishCream, "Baileys Irish Cream"),
            // IngredientAggregate.Create(IngredientIds.Campari, "Campari"),
            // IngredientAggregate.Create(IngredientIds.StGermain, "St. Germain"),
            // IngredientAggregate.Create(IngredientIds.Kahlua, "Kahlúa"),
            // IngredientAggregate.Create(IngredientIds.Chambord, "Chambord"),
            // IngredientAggregate.Create(IngredientIds.CremeDeCacao, "Crème de Cacao"),
            // IngredientAggregate.Create(IngredientIds.CremeDeMenthe, "Crème de Menthe"),
            // IngredientAggregate.Create(IngredientIds.CremeDeCassis, "Crème de Cassis"),
            // IngredientAggregate.Create(IngredientIds.Drambuie, "Drambuie"),
            // IngredientAggregate.Create(IngredientIds.Frangelico, "Frangelico"),
            // IngredientAggregate.Create(IngredientIds.GrandMarnier, "Grand Marnier"),
            // IngredientAggregate.Create(IngredientIds.Limoncello, "Limoncello"),
            // IngredientAggregate.Create(IngredientIds.MaraschinoLiqueur, "Maraschino Liqueur"),
            // IngredientAggregate.Create(IngredientIds.Midori, "Midori"),
            // IngredientAggregate.Create(IngredientIds.PeachSchnapps, "Peach Schnapps"),
            // IngredientAggregate.Create(IngredientIds.OrangeCuracao, "Orange Curaçao"),
            // IngredientAggregate.Create(IngredientIds.Cointreau, "Cointreau"),
            // IngredientAggregate.Create(IngredientIds.TripleSec, "Triple Sec"),
            // IngredientAggregate.Create(IngredientIds.GreenChartreuse, "Green Chartreuse"),
            // IngredientAggregate.Create(IngredientIds.Benedictine, "Bénédictine"),
            // IngredientAggregate.Create(IngredientIds.Galliano, "Galliano"),
            //
            // // Vermouth & Fortified Wines
            // IngredientAggregate.Create(IngredientIds.SweetVermouth, "Sweet Vermouth"),
            // IngredientAggregate.Create(IngredientIds.DryVermouth, "Dry Vermouth"),
            // IngredientAggregate.Create(IngredientIds.LilletBlanc, "Lillet Blanc"),
            // IngredientAggregate.Create(IngredientIds.Port, "Port"),
            // IngredientAggregate.Create(IngredientIds.Sherry, "Sherry"),
            //
            // // Wine & Sparkling
            // IngredientAggregate.Create(IngredientIds.Prosecco, "Prosecco"),
            //
            // // Bitters
            // IngredientAggregate.Create(IngredientIds.AngosturaBitters, "Angostura Bitters"),
            // IngredientAggregate.Create(IngredientIds.OrangeBitters, "Orange Bitters"),
            // IngredientAggregate.Create(IngredientIds.PeychaudsBitters, "Peychaud's Bitters"),
            // IngredientAggregate.Create(IngredientIds.ChocolateBitters, "Chocolate Bitters"),
            // IngredientAggregate.Create(IngredientIds.CherryBitters, "Cherry Bitters"),
            // IngredientAggregate.Create(IngredientIds.CeleryBitters, "Celery Bitters"),
            //
            // // Mixers & Sodas
            // IngredientAggregate.Create(IngredientIds.ClubSoda, "Club Soda"),
            // IngredientAggregate.Create(IngredientIds.TonicWater, "Tonic Water"),
            // IngredientAggregate.Create(IngredientIds.GingerBeer, "Ginger Beer"),
            // IngredientAggregate.Create(IngredientIds.GingerAle, "Ginger Ale"),
            // IngredientAggregate.Create(IngredientIds.Cola, "Cola"),
            // IngredientAggregate.Create(IngredientIds.Sprite, "Sprite"),
            // IngredientAggregate.Create(IngredientIds.CranberryJuice, "Cranberry Juice"),
            // IngredientAggregate.Create(IngredientIds.OrangeJuice, "Orange Juice"),
            // IngredientAggregate.Create(IngredientIds.PineappleJuice, "Pineapple Juice"),
            // IngredientAggregate.Create(IngredientIds.GrapefruitJuice, "Grapefruit Juice"),
            // IngredientAggregate.Create(IngredientIds.TomatoJuice, "Tomato Juice"),
            // IngredientAggregate.Create(IngredientIds.FreshLimeJuice, "Fresh Lime Juice"),
            // IngredientAggregate.Create(IngredientIds.FreshLemonJuice, "Fresh Lemon Juice"),
            // IngredientAggregate.Create(IngredientIds.SimpleSyrup, "Simple Syrup"),
            // IngredientAggregate.Create(IngredientIds.Grenadine, "Grenadine"),
            // IngredientAggregate.Create(IngredientIds.AgaveNectar, "Agave Nectar"),
            // IngredientAggregate.Create(IngredientIds.HoneySyrup, "Honey Syrup"),
            // IngredientAggregate.Create(IngredientIds.OrgatSyrup, "Orgeat Syrup"),
            // IngredientAggregate.Create(IngredientIds.PeachPuree, "Peach Purée"),
            // IngredientAggregate.Create(IngredientIds.PassionFruitSyrup, "Passion Fruit Syrup"),
            //
            // // Coffee
            // IngredientAggregate.Create(IngredientIds.FreshEspresso, "Fresh Espresso"),
            // IngredientAggregate.Create(IngredientIds.Coffee, "Coffee"),
            //
            // // Fresh Ingredients
            // IngredientAggregate.Create(IngredientIds.FreshLime, "Fresh Lime"),
            // IngredientAggregate.Create(IngredientIds.FreshLemon, "Fresh Lemon"),
            // IngredientAggregate.Create(IngredientIds.FreshOrange, "Fresh Orange"),
            // IngredientAggregate.Create(IngredientIds.FreshMint, "Fresh Mint"),
            // IngredientAggregate.Create(IngredientIds.FreshBasil, "Fresh Basil"),
            // IngredientAggregate.Create(IngredientIds.FreshCucumber, "Fresh Cucumber"),
            // IngredientAggregate.Create(IngredientIds.FreshGinger, "Fresh Ginger"),
            // IngredientAggregate.Create(IngredientIds.FreshBerries, "Fresh Berries"),
            // IngredientAggregate.Create(IngredientIds.EggWhite, "Egg White"),
            // IngredientAggregate.Create(IngredientIds.FreshPeach, "Fresh Peach"),
            // IngredientAggregate.Create(IngredientIds.HoneydewMelon, "Honeydew Melon"),
            //
            // // Dairy & Creams
            // IngredientAggregate.Create(IngredientIds.WhippedCream, "Whipped Cream"),
            // IngredientAggregate.Create(IngredientIds.Cream, "Cream"),
            // IngredientAggregate.Create(IngredientIds.FreshCream, "Fresh Cream"),
            //
            // // Garnishes
            // IngredientAggregate.Create(IngredientIds.Olives, "Olives"),
            // IngredientAggregate.Create(IngredientIds.CocktailOnions, "Cocktail Onions"),
            // IngredientAggregate.Create(IngredientIds.MaraschinoCherries, "Maraschino Cherries"),
            // IngredientAggregate.Create(IngredientIds.OrangePeel, "Orange Peel"),
            // IngredientAggregate.Create(IngredientIds.LemonPeel, "Lemon Peel"),
            // IngredientAggregate.Create(IngredientIds.LimeWedge, "Lime Wedge"),
            // IngredientAggregate.Create(IngredientIds.Salt, "Salt"),
            // IngredientAggregate.Create(IngredientIds.Sugar, "Sugar"),
            // IngredientAggregate.Create(IngredientIds.Nutmeg, "Nutmeg"),
            // IngredientAggregate.Create(IngredientIds.Cinnamon, "Cinnamon"),
            // IngredientAggregate.Create(IngredientIds.CoffeeBeans, "Coffee Beans")
        ];
    }
}
