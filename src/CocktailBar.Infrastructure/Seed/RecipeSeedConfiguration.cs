using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Seed;

public class RecipeSeedConfiguration : IEntityTypeConfiguration<RecipeAggregate>
{
    public void Configure(EntityTypeBuilder<RecipeAggregate> builder)
    {
        builder.HasData(GetSeedData());
    }

    private static IEnumerable<RecipeAggregate> GetSeedData()
    {
        return
        [
            RecipeAggregate.Create(
                RecipeIds.ClassicMartini,
                "Classic Martini",
                """
                1. Fill mixing glass with ice
                2. Add 2.5 oz Tanqueray Gin (or Belvedere Vodka) and 0.5 oz Dry Vermouth
                3. Stir for 30 seconds
                4. Strain into chilled martini glass
                5. Garnish with olives or lemon peel
                """
            ),

            // RecipeAggregate.Create(
            //     RecipeIds.Manhattan,
            //     "Manhattan",
            //     """
            //     1. Fill mixing glass with ice
            //     2. Add 2 oz Rittenhouse Rye, 1 oz Sweet Vermouth, and 2-3 dashes Angostura Bitters
            //     3. Stir for 30 seconds
            //     4. Strain into chilled coupe glass
            //     5. Garnish with Maraschino Cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Margarita,
            //     "Margarita",
            //     """
            //     1. Rim glass with salt if desired
            //     2. Fill shaker with ice
            //     3. Add 2 oz Blanco Tequila, 1 oz Fresh Lime Juice, and 0.75 oz Agave Nectar
            //     4. Shake vigorously for 10-15 seconds
            //     5. Strain into glass over fresh ice
            //     6. Garnish with lime wedge
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Negroni,
            //     "Negroni",
            //     """
            //     1. Fill mixing glass with ice
            //     2. Add 1 oz Tanqueray Gin, 1 oz Campari, and 1 oz Sweet Vermouth
            //     3. Stir for 30 seconds
            //     4. Strain into rocks glass over large ice cube
            //     5. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.OldFashioned,
            //     "Old Fashioned",
            //     """
            //     1. Place sugar cube in rocks glass
            //     2. Add 2-3 dashes Angostura Bitters and a splash of water
            //     3. Muddle until sugar is dissolved
            //     4. Add 2 oz Maker's Mark Bourbon
            //     5. Add large ice cube and stir
            //     6. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.MoscowMule,
            //     "Moscow Mule",
            //     """
            //     1. Fill copper mug with ice
            //     2. Add 2 oz Grey Goose Vodka and 0.5 oz Fresh Lime Juice
            //     3. Top with Ginger Beer
            //     4. Stir gently
            //     5. Garnish with lime wedge and fresh mint
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Mojito,
            //     "Mojito",
            //     """
            //     1. In shaker, muddle 8 fresh mint leaves with 0.75 oz Simple Syrup
            //     2. Add 2 oz White Rum and 1 oz Fresh Lime Juice
            //     3. Shake with ice
            //     4. Strain into highball glass over fresh ice
            //     5. Top with Club Soda
            //     6. Garnish with mint sprig
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Daiquiri,
            //     "Daiquiri",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz White Rum, 1 oz Fresh Lime Juice, and 0.75 oz Simple Syrup
            //     3. Shake vigorously for 10-15 seconds
            //     4. Double strain into chilled coupe glass
            //     5. Garnish with lime wheel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.WhiskeySour,
            //     "Whiskey Sour",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Buffalo Trace Bourbon, 1 oz Fresh Lemon Juice, and 0.75 oz Simple Syrup
            //     3. Shake vigorously
            //     4. Strain into rocks glass over fresh ice
            //     5. Optional: Float red wine on top
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.MaiTai,
            //     "Mai Tai",
            //     """
            //     1. Fill shaker with crushed ice
            //     2. Add 2 oz Dark Rum, 0.75 oz Fresh Lime Juice, 0.5 oz Orange Curaçao, and 0.5 oz Orgeat
            //     3. Shake well
            //     4. Pour into glass
            //     5. Float 0.5 oz Overproof Rum
            //     6. Garnish with mint sprig and lime wedge
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Cosmopolitan,
            //     "Cosmopolitan",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1.5 oz Citrus Vodka, 1 oz Cranberry Juice, 0.5 oz Fresh Lime Juice, and 0.5 oz Triple Sec
            //     3. Shake well
            //     4. Strain into chilled martini glass
            //     5. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.French75,
            //     "French 75",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1.5 oz Plymouth Gin, 0.75 oz Fresh Lemon Juice, and 0.5 oz Simple Syrup
            //     3. Shake well
            //     4. Strain into champagne flute
            //     5. Top with champagne
            //     6. Garnish with lemon peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Gimlet,
            //     "Gimlet",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Hendrick's Gin and 1 oz Fresh Lime Juice
            //     3. Shake well
            //     4. Strain into chilled coupe glass
            //     5. Garnish with lime wheel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.DarkNStormy,
            //     "Dark 'n' Stormy",
            //     """
            //     1. Fill highball glass with ice
            //     2. Add 2 oz Dark Rum
            //     3. Top with Ginger Beer
            //     4. Add 0.5 oz Fresh Lime Juice
            //     5. Garnish with lime wedge
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.TomCollins,
            //     "Tom Collins",
            //     """
            //     1. Fill collins glass with ice
            //     2. Add 2 oz Plymouth Gin, 1 oz Fresh Lemon Juice, and 0.5 oz Simple Syrup
            //     3. Top with Club Soda
            //     4. Stir gently
            //     5. Garnish with lemon wheel and cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Boulevardier,
            //     "Boulevardier",
            //     """
            //     1. Fill mixing glass with ice
            //     2. Add 1.5 oz Buffalo Trace Bourbon, 1 oz Campari, and 1 oz Sweet Vermouth
            //     3. Stir well
            //     4. Strain into rocks glass over ice
            //     5. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Paloma,
            //     "Paloma",
            //     """
            //     1. Rim highball glass with salt
            //     2. Fill with ice
            //     3. Add 2 oz Blanco Tequila and 0.5 oz Fresh Lime Juice
            //     4. Top with Grapefruit Juice
            //     5. Add splash of Club Soda
            //     6. Garnish with grapefruit wedge
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.MintJulep,
            //     "Mint Julep",
            //     """
            //     1. In julep cup, muddle 8 mint leaves with 0.5 oz Simple Syrup
            //     2. Add crushed ice
            //     3. Add 2.5 oz Maker's Mark Bourbon
            //     4. Stir until cup is frosted
            //     5. Garnish with mint sprig
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Vesper,
            //     "Vesper",
            //     """
            //     1. Fill mixing glass with ice
            //     2. Add 3 oz Tanqueray Gin, 1 oz Grey Goose Vodka, and 0.5 oz Lillet Blanc
            //     3. Stir well
            //     4. Strain into chilled martini glass
            //     5. Garnish with lemon peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.SingaporeSling,
            //     "Singapore Sling",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1.5 oz Plymouth Gin, 0.5 oz Cherry Liqueur, 0.25 oz Cointreau
            //     3. Add 0.25 oz Benedictine, 0.5 oz Fresh Lime Juice, 0.5 oz Pineapple Juice
            //     4. Shake well
            //     5. Strain into tall glass
            //     6. Top with Club Soda
            //     7. Garnish with cherry and pineapple
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Aviation,
            //     "Aviation",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Plymouth Gin, 0.5 oz Maraschino Liqueur, and 0.75 oz Fresh Lemon Juice
            //     3. Shake well
            //     4. Strain into chilled coupe glass
            //     5. Garnish with cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.PiscoSour,
            //     "Pisco Sour",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Pisco, 1 oz Fresh Lemon Juice, 0.75 oz Simple Syrup, and 1 egg white
            //     3. Dry shake (without ice) vigorously
            //     4. Add ice and shake again
            //     5. Strain into rocks glass
            //     6. Add 3 drops Angostura Bitters on top
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.LastWord,
            //     "Last Word",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 0.75 oz each: Plymouth Gin, Green Chartreuse, Maraschino Liqueur, and Fresh Lime Juice
            //     3. Shake well
            //     4. Strain into chilled coupe glass
            //     5. No garnish
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Sazerac,
            //     "Sazerac",
            //     """
            //     1. Rinse chilled rocks glass with absinthe, discard excess
            //     2. In mixing glass, muddle sugar cube with Peychaud's Bitters
            //     3. Add 2 oz Rittenhouse Rye and ice
            //     4. Stir well
            //     5. Strain into prepared glass
            //     6. Garnish with lemon peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.BloodAndSand,
            //     "Blood and Sand",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 0.75 oz each: Blended Scotch, Cherry Liqueur, Sweet Vermouth, and Orange Juice
            //     3. Shake well
            //     4. Strain into chilled coupe glass
            //     5. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.FrenchMartini,
            //     "French Martini",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Grey Goose Vodka, 1 oz Pineapple Juice, and 0.5 oz Chambord
            //     3. Shake vigorously
            //     4. Strain into chilled martini glass
            //     5. Garnish with raspberry or lemon twist
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.CorpseReviver2,
            //     "Corpse Reviver #2",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 0.75 oz each: Plymouth Gin, Lillet Blanc, Fresh Lemon Juice, and Triple Sec
            //     3. Add dash of Absinthe
            //     4. Shake well
            //     5. Strain into chilled coupe glass
            //     6. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.IrishCoffee,
            //     "Irish Coffee",
            //     """
            //     1. Preheat Irish coffee glass with hot water, then empty
            //     2. Add 1 oz Simple Syrup
            //     3. Add 2 oz Irish Whiskey
            //     4. Fill with hot coffee to 1 inch below rim
            //     5. Top with lightly whipped cream
            //     6. Garnish with grated nutmeg
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.WhiteRussian,
            //     "White Russian",
            //     """
            //     1. Fill rocks glass with ice
            //     2. Add 2 oz Grey Goose Vodka and 1 oz Kahlua
            //     3. Top with cream or milk
            //     4. Stir gently
            //     5. Optional: dust with cinnamon
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Sidecar,
            //     "Sidecar",
            //     """
            //     1. Sugar rim a coupe glass
            //     2. Fill shaker with ice
            //     3. Add 2 oz Cognac, 0.75 oz Fresh Lemon Juice, and 0.75 oz Triple Sec
            //     4. Shake well
            //     5. Strain into prepared glass
            //     6. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.EspressoMartini,
            //     "Espresso Martini",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Belvedere Vodka, 0.5 oz Kahlua, and 1 oz fresh espresso
            //     3. Add 0.5 oz Simple Syrup
            //     4. Shake vigorously
            //     5. Strain into chilled martini glass
            //     6. Garnish with three coffee beans
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.BAndB,
            //     "B&B",
            //     """
            //     1. Fill mixing glass with ice
            //     2. Add 1.5 oz Benedictine and 1.5 oz Cognac
            //     3. Stir well
            //     4. Strain into snifter
            //     5. Serve neat
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Penicillin,
            //     "Penicillin",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Blended Scotch, 0.75 oz Fresh Lemon Juice, and 0.75 oz Honey Syrup
            //     3. Add 3 slices fresh ginger
            //     4. Shake well
            //     5. Strain into rocks glass over ice
            //     6. Float 0.25 oz Single Malt Scotch
            //     7. Garnish with candied ginger
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Bramble,
            //     "Bramble",
            //     """
            //     1. Fill glass with crushed ice
            //     2. Add 2 oz Plymouth Gin, 1 oz Fresh Lemon Juice, and 0.5 oz Simple Syrup
            //     3. Stir
            //     4. Drizzle 0.5 oz Crème de Cassis over top
            //     5. Garnish with lemon wedge and fresh berries
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Bellini,
            //     "Bellini",
            //     """
            //     1. In champagne flute, add 2 oz Fresh Peach Puree
            //     2. Top slowly with Prosecco
            //     3. Stir gently
            //     4. Garnish with peach slice
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Godfather,
            //     "Godfather",
            //     """
            //     1. Fill rocks glass with ice
            //     2. Add 2 oz Single Malt Scotch and 0.5 oz Amaretto
            //     3. Stir gently
            //     4. Garnish with orange peel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.GoldenDream,
            //     "Golden Dream",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz Triple Sec, 1 oz Galliano, 1 oz Orange Juice, and 0.5 oz Fresh Cream
            //     3. Shake vigorously
            //     4. Strain into chilled cocktail glass
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Grasshopper,
            //     "Grasshopper",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz Crème de Menthe, 1 oz Crème de Cacao, and 1 oz Fresh Cream
            //     3. Shake well
            //     4. Strain into chilled cocktail glass
            //     5. Garnish with mint leaf
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Hurricane,
            //     "Hurricane",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Dark Rum, 2 oz White Rum
            //     3. Add 1 oz Orange Juice, 1 oz Fresh Lime Juice
            //     4. Add 1 oz Passion Fruit Syrup and 0.5 oz Grenadine
            //     5. Shake well
            //     6. Strain into hurricane glass over ice
            //     7. Garnish with orange slice and cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.JapaneseSlipper,
            //     "Japanese Slipper",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz Midori, 1 oz Triple Sec, and 1 oz Fresh Lemon Juice
            //     3. Shake well
            //     4. Strain into chilled cocktail glass
            //     5. Garnish with honeydew melon ball
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.LongIslandIcedTea,
            //     "Long Island Iced Tea",
            //     """
            //     1. Fill highball glass with ice
            //     2. Add 0.5 oz each: Vodka, Gin, White Rum, Tequila, and Triple Sec
            //     3. Add 1 oz Fresh Lemon Juice and 0.5 oz Simple Syrup
            //     4. Top with Cola
            //     5. Stir gently
            //     6. Garnish with lemon wheel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.MaryPickford,
            //     "Mary Pickford",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz White Rum, 2 oz Pineapple Juice
            //     3. Add 0.5 oz Maraschino Liqueur and 0.5 oz Grenadine
            //     4. Shake well
            //     5. Strain into chilled cocktail glass
            //     6. Garnish with Maraschino Cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Mudslide,
            //     "Mudslide",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz Vodka, 1 oz Kahlua, and 1 oz Baileys Irish Cream
            //     3. Shake well
            //     4. Strain into rocks glass filled with ice
            //     5. Optional: drizzle with chocolate syrup
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.RustyNail,
            //     "Rusty Nail",
            //     """
            //     1. Fill rocks glass with ice
            //     2. Add 2 oz Blended Scotch and 0.5 oz Drambuie
            //     3. Stir gently
            //     4. Garnish with lemon twist
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.SeaBreeze,
            //     "Sea Breeze",
            //     """
            //     1. Fill highball glass with ice
            //     2. Add 2 oz Vodka
            //     3. Add 3 oz Cranberry Juice and 1 oz Grapefruit Juice
            //     4. Stir gently
            //     5. Garnish with lime wedge
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.TequilaSunrise,
            //     "Tequila Sunrise",
            //     """
            //     1. Fill highball glass with ice
            //     2. Add 2 oz Blanco Tequila and 4 oz Orange Juice
            //     3. Stir gently
            //     4. Float 0.5 oz Grenadine
            //     5. Garnish with orange slice and cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.WardEight,
            //     "Ward Eight",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 2 oz Rye Whiskey, 0.75 oz Fresh Lemon Juice
            //     3. Add 0.75 oz Orange Juice and 0.5 oz Grenadine
            //     4. Shake well
            //     5. Strain into chilled cocktail glass
            //     6. Garnish with orange slice and cherry
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.YellowBird,
            //     "Yellow Bird",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz White Rum, 0.5 oz Galliano
            //     3. Add 0.5 oz Triple Sec and 0.5 oz Fresh Lime Juice
            //     4. Shake well
            //     5. Strain into chilled cocktail glass
            //     6. Garnish with lime wheel
            //     """
            // ),
            //
            // RecipeAggregate.Create(
            //     RecipeIds.Zombie,
            //     "Zombie",
            //     """
            //     1. Fill shaker with ice
            //     2. Add 1 oz each: White Rum, Gold Rum, Dark Rum
            //     3. Add 1 oz Fresh Lime Juice, 1 oz Pineapple Juice
            //     4. Add 0.5 oz Grenadine and 0.5 oz Simple Syrup
            //     5. Shake well
            //     6. Strain into tall glass filled with crushed ice
            //     7. Float 0.5 oz Overproof Rum
            //     8. Garnish with mint sprig and fruit
            //     """
            // )
        ];
    }
}
