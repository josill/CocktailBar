using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Aggregates.Ingredient;

/// <summary>
/// Represents the name of an ingredient in the cocktail bar system.
/// </summary>
public class IngredientName : Enumeration
{
    public static readonly IngredientName GreyGooseVodka = new(Guid.Parse("7d1c6ab3-2214-45d7-9b18-348b4df6bd2e"), "Grey Goose Vodka");
    public static readonly IngredientName BelvedereVodka = new(Guid.Parse("9e5b3f8a-1c4d-4b7e-8f2a-6d9c7b3e5d4a"), "Belvedere Vodka");
    public static readonly IngredientName AbsolutVodka = new(Guid.Parse("2f8e9c5b-7d3a-4f6e-9d2c-1b5a8e4d9c7b"), "Absolut Vodka");
    public static readonly IngredientName StolichnayaVodka = new(Guid.Parse("4a7b9c2e-8f5d-4e6a-b3c1-9d8e7f6a5b4c"), "Stolichnaya Vodka");
    public static readonly IngredientName TanquerayGin = new(Guid.Parse("6c4d8e2b-9f7a-5e3d-1c4b-8a7d6e9f3b5c"), "Tanqueray Gin");
    public static readonly IngredientName BeefeaterGin = new(Guid.Parse("8e5a7b4c-2d9f-6e1a-3b8c-7d4f9e2a5b1c"), "Beefeater Gin");
    public static readonly IngredientName PlymouthGin = new(Guid.Parse("1d4e7a9c-3b6f-5d8e-2a4b-9c7d5e8f3a6b"), "Plymouth Gin");
    public static readonly IngredientName HendricksGin = new(Guid.Parse("3f6d8b2e-5a7c-4d9e-1b3a-8c6d4e7f2a5b"), "Hendrick's Gin");
    public static readonly IngredientName MakersMark = new(Guid.Parse("5d8e2b4a-7f9c-6e1d-3b5a-2c4f8d6e7a9b"), "Maker's Mark");
    public static readonly IngredientName BuffaloTrace = new(Guid.Parse("7f9a4d2e-1b6c-8e3d-5a7b-4c2e8f9d6a3b"), "Buffalo Trace");
    public static readonly IngredientName RittenhouseRye = new(Guid.Parse("9c7b6e4d-3a8f-2d5e-7f9a-6b4d8c2e5a1b"), "Rittenhouse Rye");
    public static readonly IngredientName BulleitRye = new(Guid.Parse("2e4d6b8a-5c7f-9e1d-3b5a-8f2c4d6e7a9b"), "Bulleit Rye");
    public static readonly IngredientName WhiteRum = new(Guid.Parse("4f8e2d6b-7a9c-1e3d-5b7f-2a4c6e8d9b3a"), "White Rum");
    public static readonly IngredientName GoldRum = new(Guid.Parse("6b8c4e2d-9f7a-3e5d-1b7c-4a6f8d2e5b9a"), "Gold Rum");
    public static readonly IngredientName DarkRum = new(Guid.Parse("8d6e2b4c-1f9a-5e7d-3b5c-6a8f4d2e7b9a"), "Dark Rum");
    public static readonly IngredientName SpicedRum = new(Guid.Parse("2b4d6e8c-3f7a-5d9e-1b5c-8a2f4d6e7b9a"), "Spiced Rum");
    public static readonly IngredientName BlancoTequila = new(Guid.Parse("4e6b8d2c-5f9a-7e1d-3b5c-2a4f6d8e9b7a"), "Blanco Tequila");
    public static readonly IngredientName ReposadoTequila = new(Guid.Parse("6d8c4b2e-7f9a-1e3d-5b5c-4a2f6d8e9b7a"), "Reposado Tequila");
    public static readonly IngredientName AnejoTequila = new(Guid.Parse("8e2d4b6c-9f7a-3e5d-1b5c-6a2f4d8e9b7a"), "Añejo Tequila");
    public static readonly IngredientName Mezcal = new(Guid.Parse("2b4e6d8c-1f9a-5e7d-3b5c-8a2f4d6e9b7a"), "Mezcal");
    public static readonly IngredientName Amaretto = new(Guid.Parse("4d6b8e2c-3f9a-7e5d-1b5c-2a4f6d8e9b7a"), "Amaretto");
    public static readonly IngredientName BaileysIrishCream = new(Guid.Parse("6e8d2b4c-5f9a-1e7d-3b5c-4a2f6d8e9b7a"), "Baileys Irish Cream");
    public static readonly IngredientName Campari = new(Guid.Parse("8b2e4d6c-7f9a-3e5d-1b5c-6a2f4d8e9b7a"), "Campari");
    public static readonly IngredientName StGermain = new(Guid.Parse("2d4b6e8c-9f7a-5e1d-3b5c-8a2f4d6e9b7a"), "St-Germain");
    public static readonly IngredientName Kahlua = new(Guid.Parse("4e6d8b2c-1f9a-7e5d-3b5c-2a4f6d8e9b7a"), "Kahlúa");
    public static readonly IngredientName SweetVermouth = new(Guid.Parse("6b8e2d4c-3f9a-1e7d-5b5c-4a2f6d8e9b7a"), "Sweet Vermouth");
    public static readonly IngredientName DryVermouth = new(Guid.Parse("8d2b4e6c-5f9a-3e7d-1b5c-6a2f4d8e9b7a"), "Dry Vermouth");
    public static readonly IngredientName LilletBlanc = new(Guid.Parse("2e4d6b8c-7f9a-5e1d-3b5c-8a2f4d6e9b7a"), "Lillet Blanc");
    public static readonly IngredientName AngosturaBitters = new(Guid.Parse("4b6e8d2c-9f7a-1e5d-3b5c-2a4f6d8e9b7a"), "Angostura Bitters");
    public static readonly IngredientName OrangeBitters = new(Guid.Parse("6d8b2e4c-1f9a-3e7d-5b5c-4a2f6d8e9b7a"), "Orange Bitters");
    public static readonly IngredientName PeychaudsBitters = new(Guid.Parse("8e2d4b6c-3f9a-5e7d-1b5c-6a2f4d8e9b7a"), "Peychaud's Bitters");
    public static readonly IngredientName ClubSoda = new(Guid.Parse("2b4e6d8c-5f9a-7e1d-3b5c-8a2f4d6e9b7a"), "Club Soda");
    public static readonly IngredientName TonicWater = new(Guid.Parse("4d6b8e2c-7f9a-1e5d-3b5c-2a4f6d8e9b7a"), "Tonic Water");
    public static readonly IngredientName GingerBeer = new(Guid.Parse("6e8d2b4c-9f7a-3e7d-5b5c-4a2f6d8e9b7a"), "Ginger Beer");
    public static readonly IngredientName SimpleSyrup = new(Guid.Parse("8b2e4d6c-1f9a-5e7d-3b5c-6a2f4d8e9b7a"), "Simple Syrup");
    public static readonly IngredientName Grenadine = new(Guid.Parse("2d4b6e8c-3f9a-7e1d-5b5c-8a2f4d8e9b7a"), "Grenadine");
    public static readonly IngredientName LimeJuice = new(Guid.Parse("4e6d8b2c-5f9a-1e7d-3b5c-2a4f6d8e9b7a"), "Lime Juice");
    public static readonly IngredientName LemonJuice = new(Guid.Parse("6b8e2d4c-7f9a-3e7d-5b5c-4a2f6d8e9b7a"), "Lemon Juice");
    public static readonly IngredientName OrangeJuice = new(Guid.Parse("8d2b4e6c-9f7a-5e7d-1b5c-6a2f4d8e9b7a"), "Orange Juice");
    public static readonly IngredientName CranberryJuice = new(Guid.Parse("2e4d6b8c-1f9a-7e5d-3b5c-8a2f4d8e9b7a"), "Cranberry Juice");
    public static readonly IngredientName PineappleJuice = new(Guid.Parse("4b6e8d2c-3f9a-5e7d-1b5c-2a4f6d8e9b7a"), "Pineapple Juice");
    public static readonly IngredientName MintLeaves = new(Guid.Parse("6d8b2e4c-5f9a-7e1d-3b5c-4a2f6d8e9b7a"), "Mint Leaves");
    public static readonly IngredientName LimeWedge = new(Guid.Parse("8e2d4b6c-7f9a-1e5d-3b5c-6a2f4d8e9b7a"), "Lime Wedge");
    public static readonly IngredientName LemonTwist = new(Guid.Parse("2b4e6d8c-3f9a-3e7d-5b5c-8a2f4d8e9b7a"), "Lemon Twist");
    public static readonly IngredientName OrangePeel = new(Guid.Parse("4d6b8e2c-5f9a-5e7d-1b5c-2a4f6d8e9b7a"), "Orange Peel");
    public static readonly IngredientName MaraschinoCherries = new(Guid.Parse("6e8d2b4c-7f9a-7e1d-3b5c-4a2f6d8e9b7a"), "Maraschino Cherries");
    public static readonly IngredientName Olives = new(Guid.Parse("8b2e4d6c-9f7a-1e5d-3b5c-6a2f4d8e9b7a"), "Olives");

    private IngredientName() {} // Private constructor for EF Core

    private IngredientName(Guid id, string name) : base(id, name)
    {
    }
}
