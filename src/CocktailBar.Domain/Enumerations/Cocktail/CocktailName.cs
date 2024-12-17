using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.Enumerations.Cocktail;

/// <summary>
/// Represents the name of the cocktail.
/// </summary>
public class CocktailName : Enumeration
{
    public static readonly CocktailName ClassicMartini = new(Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"), "Classic Martini");
    public static readonly CocktailName Manhattan = new(Guid.Parse("c8d57d88-6f11-4d5c-9c02-c08876836195"), "Manhattan");
    public static readonly CocktailName Margarita = new(Guid.Parse("fd391135-6ad6-4c64-8310-5bc9608d3b2b"), "Margarita");
    public static readonly CocktailName Mojito = new(Guid.Parse("e04ef027-7506-4f9b-a645-bb178ae76674"), "Mojito");
    public static readonly CocktailName SkinnyBitch = new(Guid.Parse("49b3c6ac-d25d-48cd-8c8a-a4cf988a4021"), "Skinny Bitch");
    public static readonly CocktailName OldFashioned = new(Guid.Parse("e7d7a4b7-dc42-4f3c-9547-3178214501ed"), "Old Fashioned");
    public static readonly CocktailName Negroni = new(Guid.Parse("6e912c49-bd64-4b32-9d1c-8ec13735b8d8"), "Negroni");
    public static readonly CocktailName Daiquiri = new(Guid.Parse("f85de729-13b1-4e4d-a7a7-24d903323c95"), "Daiquiri");
    public static readonly CocktailName WhiskeySour = new(Guid.Parse("b2c92185-53a4-4425-945d-34da8bef9e2e"), "Whiskey Sour");
    public static readonly CocktailName MoscowMule = new(Guid.Parse("d4fb5f15-7d8f-4c82-9787-1c3e07f132c9"), "Moscow Mule");
    public static readonly CocktailName GinAndTonic = new(Guid.Parse("a98f4c2b-1e4d-4b6a-9c34-8d3f5e6b7a0c"), "Gin and Tonic");
    public static readonly CocktailName DarkAndStormy = new(Guid.Parse("b7c9e5d2-3f8a-4b1c-9d6e-7f4a2b1c8d0e"), "Dark and Stormy");
    public static readonly CocktailName PinaColada = new(Guid.Parse("c6b8f4e2-5d9a-4c3b-8e7f-6a1b2c3d4e5f"), "Piña Colada");
    public static readonly CocktailName Cosmopolitan = new(Guid.Parse("d5a7e3c1-6b8d-4f2e-9c4b-5a1b2c3d4e5f"), "Cosmopolitan");
    public static readonly CocktailName BloodyMary = new(Guid.Parse("e4b6d2c8-7a9f-4e3d-8b5c-6a1b2c3d4e5f"), "Bloody Mary");
    public static readonly CocktailName MaiTai = new(Guid.Parse("f3c5b1a7-8e0d-4f2c-9b3a-5a1b2c3d4e5f"), "Mai Tai");
    public static readonly CocktailName LongIslandIcedTea = new(Guid.Parse("a2b4c6e8-d0f2-4e6a-8c0b-1a1b2c3d4e5f"), "Long Island Iced Tea");
    public static readonly CocktailName Gimlet = new(Guid.Parse("b1c3d5e7-f9a2-4b6c-8e0d-2a1b2c3d4e5f"), "Gimlet");
    public static readonly CocktailName TomCollins = new(Guid.Parse("c2d4e6f8-a1b3-4c5e-7d9f-3a1b2c3d4e5f"), "Tom Collins");
    public static readonly CocktailName FrenchMartini = new(Guid.Parse("d3e5f7a9-b2c4-4d6f-8e0a-4a1b2c3d4e5f"), "French Martini");
    public static readonly CocktailName Sidecar = new(Guid.Parse("e4f6a8b0-c3d5-4e7f-9f1b-5a1b2c3d4e5f"), "Sidecar");
    public static readonly CocktailName Boulevardier = new(Guid.Parse("f5a7b9c1-d4e6-4f8f-0f2c-6a1b2c3d4e5f"), "Boulevardier");
    public static readonly CocktailName AmarettoSour = new(Guid.Parse("a6b8c0d2-e5f7-4f9f-1f3d-7a1b2c3d4e5f"), "Amaretto Sour");
    public static readonly CocktailName MintJulep = new(Guid.Parse("b7c9d1e3-f6a8-4f0f-2f4e-8a1b2c3d4e5f"), "Mint Julep");
    public static readonly CocktailName Caipirinha = new(Guid.Parse("c8d0e2f4-a7b9-4f1f-3f5f-9a1b2c3d4e5f"), "Caipirinha");
    public static readonly CocktailName FrenchConnection = new(Guid.Parse("d9e1f3a5-b8c0-4f2f-4f6f-aa1b2c3d4e5f"), "French Connection");
    public static readonly CocktailName KirRoyale = new(Guid.Parse("e0f2a4b6-c9d1-4f3f-5f7f-ba1b2c3d4e5f"), "Kir Royale");
    public static readonly CocktailName LastWord = new(Guid.Parse("f1a3b5c7-d0e2-4f4f-6f8f-ca1b2c3d4e5f"), "Last Word");
    public static readonly CocktailName PalmBeach = new(Guid.Parse("a2b4c6d8-e1f3-4f5f-7f9f-da1b2c3d4e5f"), "Palm Beach");
    public static readonly CocktailName Vesper = new(Guid.Parse("b3c5d7e9-f2a4-4f6f-8f0f-ea1b2c3d4e5f"), "Vesper");
    public static readonly CocktailName Aviation = new(Guid.Parse("c4d6e8f0-a3b5-4f7f-9f1f-fa1b2c3d4e5f"), "Aviation");
    public static readonly CocktailName BetweenTheSheets = new(Guid.Parse("d5e7f9a1-b4c6-4f8f-0f2f-ab1b2c3d4e5f"), "Between the Sheets");
    public static readonly CocktailName Bramble = new(Guid.Parse("e6f8a0b2-c5d7-4f9f-1f3f-bb1b2c3d4e5f"), "Bramble");
    public static readonly CocktailName BrandyAlexander = new(Guid.Parse("f7a9b1c3-d6e8-4f0f-2f4f-cb1b2c3d4e5f"), "Brandy Alexander");
    public static readonly CocktailName CorporateRaider = new(Guid.Parse("a8b0c2d4-e7f9-4f1f-3f5f-db1b2c3d4e5f"), "Corporate Raider");
    public static readonly CocktailName FrenchConnection75 = new(Guid.Parse("b9c1d3e5-f8a0-4f2f-4f6f-eb1b2c3d4e5f"), "French 75");
    public static readonly CocktailName GodFather = new(Guid.Parse("c0d2e4f6-a9b1-4f3f-5f7f-fb1b2c3d4e5f"), "God Father");
    public static readonly CocktailName GodMother = new(Guid.Parse("d1e3f5a7-b0c2-4f4f-6f8f-1c1b2c3d4e5f"), "God Mother");
    public static readonly CocktailName GrasshopperCocktail = new(Guid.Parse("e2f4a6b8-c1d3-4f5f-7f9f-2c1b2c3d4e5f"), "Grasshopper");
    public static readonly CocktailName HarveyWallbanger = new(Guid.Parse("f3a5b7c9-d2e4-4f6f-8f0f-3c1b2c3d4e5f"), "Harvey Wallbanger");
    public static readonly CocktailName IrishCoffee = new(Guid.Parse("a4b6c8d0-e3f5-4f7f-9f1f-4c1b2c3d4e5f"), "Irish Coffee");
    public static readonly CocktailName KissesInTheDark = new(Guid.Parse("b5c7d9e1-f4a6-4f8f-0f2f-5c1b2c3d4e5f"), "Kisses in the Dark");
    public static readonly CocktailName LemonDrop = new(Guid.Parse("c6d8e0f2-a5b7-4f9f-1f3f-6c1b2c3d4e5f"), "Lemon Drop");
    public static readonly CocktailName MonkeyGland = new(Guid.Parse("d7e9f1a3-b6c8-4f0f-2f4f-7c1b2c3d4e5f"), "Monkey Gland");
    public static readonly CocktailName PeachCrush = new(Guid.Parse("e8f0a2b4-c7d9-4f1f-3f5f-8c1b2c3d4e5f"), "Peach Crush");
    public static readonly CocktailName PlantersPunch = new(Guid.Parse("f9a1b3c5-d8e0-4f2f-4f6f-9c1b2c3d4e5f"), "Planter's Punch");
    public static readonly CocktailName RustyNail = new(Guid.Parse("a0b2c4d6-e9f1-4f3f-5f7f-ac1b2c3d4e5f"), "Rusty Nail");
    public static readonly CocktailName SaltyDog = new(Guid.Parse("b1c3d5e7-f0a2-4f4f-6f8f-bc1b2c3d4e5f"), "Salty Dog");
    public static readonly CocktailName Sazerac = new(Guid.Parse("c2d4e6f8-a1b3-4f5f-7f9f-cc1b2c3d4e5f"), "Sazerac");
    public static readonly CocktailName Singapore = new(Guid.Parse("d3e5f7a9-b2c4-4f6f-8f0f-dc1b2c3d4e5f"), "Singapore Sling");
    public static readonly CocktailName StrawberryDaiquiri = new(Guid.Parse("e4f6a8b0-c3d5-4f7f-9f1f-ec1b2c3d4e5f"), "Strawberry Daiquiri");
    public static readonly CocktailName Tequilasunrise = new(Guid.Parse("f5a7b9c1-d4e6-4f8f-0f2f-fc1b2c3d4e5f"), "Tequila Sunrise");
    public static readonly CocktailName Ward8 = new(Guid.Parse("a6b8c0d2-e5f7-4f9f-1f3f-1d1b2c3d4e5f"), "Ward 8");
    public static readonly CocktailName WhiteRussian = new(Guid.Parse("b7c9d1e3-f6a8-4f0f-2f4f-2d1b2c3d4e5f"), "White Russian");
    public static readonly CocktailName YellowBird = new(Guid.Parse("c8d0e2f4-a7b9-4f1f-3f5f-3d1b2c3d4e5f"), "Yellow Bird");

    private CocktailName() {} // Private constructor for EF Core

    private CocktailName(Guid id, string name) : base(id, name) {}
}
