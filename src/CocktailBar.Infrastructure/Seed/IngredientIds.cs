using CocktailBar.Domain.Aggregates.Ingredient;

namespace CocktailBar.Infrastructure.Seed;

public static class IngredientIds
{
    // Base Spirits - Vodka
    public static readonly IngredientId GreyGooseVodka = new(Guid.Parse("f8c62fb2-7bb8-4c8d-b88c-d4a7b89f1273"));
    public static readonly IngredientId BelvedereVodka = new(Guid.Parse("80c5b839-1b17-4a66-a894-07f675070b9c"));
    public static readonly IngredientId AbsolutVodka = new(Guid.Parse("6a7c8b3f-451c-4e9a-b795-ec5883714a9a"));
    public static readonly IngredientId StolichnayaVodka = new(Guid.Parse("d1a3e2c4-1f34-4b5d-9c6b-8a7f0e912d3b"));
    public static readonly IngredientId CitrusVodka = new(Guid.Parse("b9f5d8e7-6c2a-4b3d-9e8f-7a1c6d4b3e2a"));
    public static readonly IngredientId VanillaVodka = new(Guid.Parse("c4b3a2d1-8e7f-4c6b-9d5a-2b3e4f5c6d7a"));

    // TODO: change Guid to IngredientId
    // Base Spirits - Gin
    public static readonly Guid TanquerayGin = new("e8d7c6b5-a4f3-4e2d-9b8a-7c6d5e4f3a2b");
    public static readonly Guid BeefeaterGin = new("f7e6d5c4-b3a2-4d1e-8c7b-6a5b4c3d2e1f");
    public static readonly Guid PlymouthGin = new("a1b2c3d4-e5f6-4a3b-8c7d-9e8f7a6b5c4d");
    public static readonly Guid HendricksGin = new("b2c3d4e5-f6a7-4b3c-9d8e-1a2b3c4d5e6f");

    // Base Spirits - Whiskey
    public static readonly Guid MakersMark = new("c3d4e5f6-a7b8-4c3d-ae9f-2b3c4d5e6f7a");
    public static readonly Guid BuffaloTrace = new("d4e5f6a7-b8c9-4d3e-bf0a-3c4d5e6f7a8b");
    public static readonly Guid RittenhouseRye = new("e5f6a7b8-c9d0-4e3f-c0b1-4d5e6f7a8b9c");
    public static readonly Guid BulleitRye = new("f6a7b8c9-d0e1-4f3a-d1c2-5e6f7a8b9c0d");
    public static readonly Guid BlendedScotch = new("a7b8c9d0-e1f2-4a3b-e2d3-6f7a8b9c0d1e");
    public static readonly Guid SingleMaltScotch = new("b8c9d0e1-f2a3-4b3c-f3e4-7a8b9c0d1e2f");
    public static readonly Guid IrishWhiskey = new("c9d0e1f2-a3b4-4c3d-a4f5-8b9c0d1e2f3a");
    public static readonly Guid JapaneseWhisky = new("d0e1f2a3-b4c5-4d3e-b5a6-9c0d1e2f3a4b");

    // Base Spirits - Rum
    public static readonly Guid WhiteRum = new("e1f2a3b4-c5d6-4e3f-c6b7-0d1e2f3a4b5c");
    public static readonly Guid GoldRum = new("f2a3b4c5-d6e7-4f3a-d7c8-1e2f3a4b5c6d");
    public static readonly Guid DarkRum = new("a3b4c5d6-e7f8-4a3b-e8d9-2f3a4b5c6d7e");
    public static readonly Guid SpicedRum = new("b4c5d6e7-f8a9-4b3c-f9e0-3a4b5c6d7e8f");
    public static readonly Guid OverproofRum = new("c5d6e7f8-a9b0-4c3d-a0f1-4b5c6d7e8f9a");
    public static readonly Guid CoconutRum = new("d6e7f8a9-b0c1-4d3e-b1a2-5c6d7e8f9a0b");

    // Base Spirits - Tequila
    public static readonly Guid BlancoTequila = new("9d8f7e6d-5c4b-4a3e-9f8e-7d6c5b4a3e2d");
    public static readonly Guid ReposadoTequila = new("8e7d6c5b-4a3f-4b2e-8e7d-6c5b4a3f2e1d");
    public static readonly Guid AnejoTequila = new("7f6e5d4c-3b2a-4c1f-7f6e-5d4c3b2a1f0e");
    public static readonly Guid Mezcal = new("6e5d4c3b-2a1f-4d0e-6e5d-4c3b2a1f0e9d");

    // Base Spirits - Other
    public static readonly Guid Pisco = new("a7d8e9f0-b1c2-4d3e-9f0a-1b2c3d4e5f6a");
    public static readonly Guid Cognac = new("b8e9f0a1-c2d3-4e4f-a0b1-2c3d4e5f6a7b");
    public static readonly Guid Absinthe = new("f2c3d4e5-a6b7-4c8d-e4f5-6a7b8c9d0e1f");

    // Liqueurs & Cordials
    public static readonly Guid Amaretto = new("5d4c3b2a-1f0e-4e9d-5d4c-3b2a1f0e9d8e");
    public static readonly Guid BaileysIrishCream = new("4c3b2a1f-0e9d-4f8c-4c3b-2a1f0e9d8e7d");
    public static readonly Guid Campari = new("3b2a1f0e-9d8c-4a7b-3b2a-1f0e9d8c7b6a");
    public static readonly Guid StGermain = new("2a1f0e9d-8c7b-4b6a-2a1f-0e9d8c7b6a5d");
    public static readonly Guid Kahlua = new("1f0e9d8c-7b6a-4c59-1f0e-9d8c7b6a5d4c");
    public static readonly Guid Chambord = new("0e9d8c7b-6a5d-4d48-0e9d-8c7b6a5d4c3b");
    public static readonly Guid CremeDeCacao = new("9c8b7a6d-5e4f-4e37-9c8b-7a6d5e4f3e2d");
    public static readonly Guid CremeDeMenthe = new("8b7a6d5e-4f3e-4f26-8b7a-6d5e4f3e2d1c");
    public static readonly Guid CremeDeCassis = new("7a6d5e4f-3e2d-4a15-7a6d-5e4f3e2d1c0b");
    public static readonly Guid Drambuie = new("6d5e4f3e-2d1c-4b04-6d5e-4f3e2d1c0b9a");
    public static readonly Guid Frangelico = new("5e4f3e2d-1c0b-4c93-5e4f-3e2d1c0b9a8b");
    public static readonly Guid GrandMarnier = new("4f3e2d1c-0b9a-4d82-4f3e-2d1c0b9a8b7c");
    public static readonly Guid Limoncello = new("3e2d1c0b-9a8b-4e71-3e2d-1c0b9a8b7c6d");
    public static readonly Guid MaraschinoLiqueur = new("2d1c0b9a-8b7c-4f60-2d1c-0b9a8b7c6d5e");
    public static readonly Guid Midori = new("1c0b9a8b-7c6d-4a59-1c0b-9a8b7c6d5e4f");
    public static readonly Guid PeachSchnapps = new("0b9a8b7c-6d5e-4b48-0b9a-8b7c6d5e4f3e");
    public static readonly Guid OrangeCuracao = new("e8f7a6b5-4c3d-4e2f-b1a0-9d8c7b6a5e4d");
    public static readonly Guid Cointreau = new("d7e6b5a4-3c2d-4d1e-a0b9-8c7b6a5e4d3c");
    public static readonly Guid TripleSec = new("c6d5a4b3-2b1c-4c0d-90a8-7b6a5e4d3c2b");
    public static readonly Guid GreenChartreuse = new("c9f0a1b2-d3e4-4f5a-b1c2-3d4e5f6a7b8c");
    public static readonly Guid Benedictine = new("d0a1b2c3-e4f5-4a6b-c2d3-4e5f6a7b8c9d");
    public static readonly Guid Galliano = new("e1b2c3d4-f5a6-4b7c-d3e4-5f6a7b8c9d0e");

    // Vermouth & Fortified Wines
    public static readonly Guid SweetVermouth = new("48a9b7c6-d5e4-4f3a-b2c1-0d9e8f7a6b5c");
    public static readonly Guid DryVermouth = new("b8c7d6e5-f4a3-4b26-b8c7-d6e5f4a3b2c1");
    public static readonly Guid LilletBlanc = new("c7d6e5f4-a3b2-4c15-c7d6-e5f4a3b2c1d0");
    public static readonly Guid Port = new("d6e5f4a3-b2c1-4d04-d6e5-f4a3b2c1d0e9");
    public static readonly Guid Sherry = new("e5f4a3b2-c1d0-4e93-e5f4-a3b2c1d0e9f8");

    // Wine & Sparkling
    public static readonly Guid Prosecco = new("03d4e5f6-b7c8-4d9e-f5a6-7b8c9d0e1f2a");

    // Bitters
    public static readonly Guid AngosturaBitters = new("2e6c48eb-4b38-48c4-a0b2-b45e98417423");
    public static readonly Guid OrangeBitters = new("c7a8bf36-1e2d-4c5f-9e8d-7b6a5c4d3e2f");
    public static readonly Guid PeychaudsBitters = new("b2c1d0e9-f8a7-4b60-b2c1-d0e9f8a7b6c5");
    public static readonly Guid ChocolateBitters = new("c1d0e9f8-a7b6-4c59-c1d0-e9f8a7b6c5d4");
    public static readonly Guid CherryBitters = new("d0e9f8a7-b6c5-4d48-d0e9-f8a7b6c5d4e3");
    public static readonly Guid CeleryBitters = new("e9f8a7b6-c5d4-4e37-e9f8-a7b6c5d4e3f2");

    // Mixers & Sodas
    public static readonly Guid ClubSoda = new("9d8e7f6a-5b4c-4d3e-2f1a-0b9c8d7e6f5a");
    public static readonly Guid TonicWater = new("1f2e3d4c-5b6a-4789-9876-543210fedcba");
    public static readonly Guid GingerBeer = new("b6c5d4e3-f2a1-4b04-b6c5-d4e3f2a1b0c9");
    public static readonly Guid GingerAle = new("c5d4e3f2-a1b0-4c93-c5d4-e3f2a1b0c9d8");
    public static readonly Guid Cola = new("d4e3f2a1-b0c9-4d82-d4e3-f2a1b0c9d8e7");
    public static readonly Guid Sprite = new("e3f2a1b0-c9d8-4e71-e3f2-a1b0c9d8e7f6");
    public static readonly Guid CranberryJuice = new("f2a1b0c9-d8e7-4f60-f2a1-b0c9d8e7f6a5");
    public static readonly Guid OrangeJuice = new("a1b0c9d8-e7f6-4a59-a1b0-c9d8e7f6a5b4");
    public static readonly Guid PineappleJuice = new("b0c9d8e7-f6a5-4b48-b0c9-d8e7f6a5b4c3");
    public static readonly Guid GrapefruitJuice = new("c9d8e7f6-a5b4-4c37-c9d8-e7f6a5b4c3d2");
    public static readonly Guid TomatoJuice = new("d8e7f6a5-b4c3-4d26-d8e7-f6a5b4c3d2e1");
    public static readonly Guid FreshLimeJuice = new("e7f6a5b4-c3d2-4e15-e7f6-a5b4c3d2e1f0");
    public static readonly Guid FreshLemonJuice = new("f6a5b4c3-d2e1-4f04-f6a5-b4c3d2e1f0a9");
    public static readonly Guid SimpleSyrup = new("a5b4c3d2-e1f0-4a93-a5b4-c3d2e1f0a9b8");
    public static readonly Guid Grenadine = new("b4c3d2e1-f0a9-4b82-b4c3-d2e1f0a9b8c7");
    public static readonly Guid AgaveNectar = new("c3d2e1f0-a9b8-4c71-c3d2-e1f0a9b8c7d6");
    public static readonly Guid HoneySyrup = new("d2e1f0a9-b8c7-4d60-d2e1-f0a9b8c7d6e5");
    public static readonly Guid OrgatSyrup = new("b5c4a3b2-1a0b-4b9c-89a7-6a5e4d3c2b1a");
    public static readonly Guid PeachPuree = new("47b8c9d0-f1a2-4b3c-d9e0-1f2a3b4c5d6e");
    public static readonly Guid PassionFruitSyrup = new("58c9d0e1-a2b3-4c4d-e0f1-2a3b4c5d6e7f");

    // Coffee
    public static readonly Guid FreshEspresso = new("14e5f6a7-c8d9-4e0f-a6b7-8c9d0e1f2a3b");
    public static readonly Guid Coffee = new("27a3191d-99d4-4241-9b1c-b54b4132584b");

    // Fresh Ingredients
    public static readonly Guid FreshLime = new("7a6b5c4d-3e2f-4159-8b7a-6d5e4f3e2d1c");
    public static readonly Guid FreshLemon = new("f0a9b8c7-d6e5-4f48-f0a9-b8c7d6e5f4a3");
    public static readonly Guid FreshOrange = new("8f7e6d5c-4b3a-2918-7654-3210abcdef98");
    public static readonly Guid FreshMint = new("16b5ddb7-ca87-4268-915d-e1d53d0d38ea");
    public static readonly Guid FreshBasil = new("3f2e1d0c-9b8a-47c6-b5a4-c3b2a1d0e9f8");
    public static readonly Guid FreshCucumber = new("2e1d0c9b-8a7f-46b5-a4c3-b2a1d0e9f8a7");
    public static readonly Guid FreshGinger = new("1d0c9b8a-7f6e-45a4-93b2-a1d0e9f8a7b6");
    public static readonly Guid FreshBerries = new("0c9b8a7f-6e5d-44c3-82a1-d0e9f8a7b6c5");
    public static readonly Guid EggWhite = new("a4b3c2d1-0908-4a8b-78a6-5e4d3c2b1a09");
    public static readonly Guid FreshPeach = new("25f6a7b8-d9e0-4f1a-b7c8-9d0e1f2a3b4c");
    public static readonly Guid HoneydewMelon = new("36a7b8c9-e0f1-4a2b-c8d9-0e1f2a3b4c5d");

    // Dairy & Creams
    public static readonly Guid WhippedCream = new("69d0e1f2-b3c4-4d5e-f1a2-3b4c5d6e7f8a");
    public static readonly Guid Cream = new("70e1f2a3-c4d5-4e6f-a2b3-4c5d6e7f8a9b");
    public static readonly Guid FreshCream = new("81f2a3b4-d5e6-4f7a-b3c4-5d6e7f8a9b0c");

    // Garnishes
    public static readonly Guid Olives = new("9b8a7f6e-5d4c-43b2-71a1-d0e9f8a7b6c5");
    public static readonly Guid CocktailOnions = new("8a7f6e5d-4c3b-42a1-60d0-e9f8a7b6c5d4");
    public static readonly Guid MaraschinoCherries = new("7f6e5d4c-3b2a-41d0-59e9-f8a7b6c5d4e3");
    public static readonly Guid OrangePeel = new("6e5d4c3b-2a1f-40c9-48d8-e7f6a5b4c3d2");
    public static readonly Guid LemonPeel = new("5d4c3b2a-1f0e-4f98-37c7-d6e5f4a3b2c1");
    public static readonly Guid LimeWedge = new("4c3b2a1f-0e9d-4e87-26b6-c5d4e3f2a1b0");
    public static readonly Guid Salt = new("3b2a1f0e-9d8c-4d76-15a5-b4c3d2e1f0a9");
    public static readonly Guid Sugar = new("2a1f0e9d-8c7b-4c65-04a4-a3b2c1d0e9f8");
    public static readonly Guid Nutmeg = new("1f0e9d8c-7b6a-4b54-93b3-92a1b0c9d8e7");
    public static readonly Guid Cinnamon = new("0e9d8c7b-6a5d-4a43-82a2-81a0b9c8d7e6");
    public static readonly Guid CoffeeBeans = new("92a3b4c5-e6f7-4a8b-c4d5-6e7f8a9b0c1d");
}
