using CocktailBar.Domain.Aggregates.Recipe;

namespace CocktailBar.Infrastructure.Seed;

public static class RecipeIds
{
    public static readonly RecipeId ClassicMartini = new(Guid.Parse("f8c62fb2-7bb8-4c8d-b88c-d4a7b89f1273"));
    // TODO: Change Guid to RecipeId
    public static readonly Guid Manhattan = new("a91e6e4d-c75f-4b6c-9147-b96558c0c8d7");
    public static readonly Guid Margarita = new("b592f953-0943-4b56-9d5a-8662acdc4e45");
    public static readonly Guid Negroni = new("c3d87e68-1a5d-4b58-8d3f-736724addec5");
    public static readonly Guid OldFashioned = new("d4e98f79-2b6e-4c5a-9e40-848835d2f643");
    public static readonly Guid MoscowMule = new("e5f09a8b-3c7f-4d6c-af41-959946e3a724");
    public static readonly Guid Mojito = new("f6a1ab9c-4d80-4e7d-ba42-06a057f4b825");
    public static readonly Guid Daiquiri = new("a7b2bc0d-5e91-4f8e-cb43-17b168a5c926");
    public static readonly Guid WhiskeySour = new("b8c3cd1e-6f02-4a9f-dc44-28c279b6d027");
    public static readonly Guid MaiTai = new("c9d4de2f-7a13-4b0a-ed45-39d380c7e128");
    public static readonly Guid Cosmopolitan = new("d0e5ef3a-8b24-4c1b-fe46-40e491d8f229");
    public static readonly Guid French75 = new("e1f6fa4b-9c35-4d2c-af47-51f502e9a330");
    public static readonly Guid Gimlet = new("f2a7ab5c-0d46-4e3d-ba48-62a613f0b431");
    public static readonly Guid DarkNStormy = new("a3b8bc6d-1e57-4f4e-cb49-73b724a1c532");
    public static readonly Guid TomCollins = new("b4c9cd7e-2f68-4a5f-dc50-84c835b2d633");
    public static readonly Guid Boulevardier = new("c5d0de8f-3a79-4b6a-ed51-95d946c3e734");
    public static readonly Guid Paloma = new("d6e1ef9a-4b80-4c7b-fe52-06e057d4f835");
    public static readonly Guid MintJulep = new("e7f2fa0b-5c91-4d8c-af53-17f168e5a936");
    public static readonly Guid Vesper = new("f8a3ab1c-6d02-4e9d-ba54-28a279f6b037");
    public static readonly Guid SingaporeSling = new("a9b4bc2d-7e13-4f0e-cb55-39b380a7c138");
    public static readonly Guid Aviation = new("b0c5cd3e-8f24-4a1f-dc56-40c491b8d239");
    public static readonly Guid PiscoSour = new("c1d6de4f-9a35-4b2a-ed57-51d502c9e340");
    public static readonly Guid LastWord = new("d2e7ef5a-0b46-4c3b-fe58-62e613d0f441");
    public static readonly Guid Sazerac = new("e3f8fa6b-1c57-4d4c-af59-73f724e1a542");
    public static readonly Guid BloodAndSand = new("f4a9ab7c-2d68-4e5d-ba60-84a835f2b643");
    public static readonly Guid FrenchMartini = new("a5b0bc8d-3e79-4f6e-cb61-95b946a3c744");
    public static readonly Guid CorpseReviver2 = new("b6c1cd9e-4f80-4a7f-dc62-06c057b4d845");
    public static readonly Guid IrishCoffee = new("c7d2deaf-5a91-4b8a-ed63-17d168c5e946");
    public static readonly Guid WhiteRussian = new("d8e3efba-6b02-4c9b-fe64-28e279d6f047");
    public static readonly Guid Sidecar = new("e9f4facb-7c13-4d0c-af65-39f380e7a148");
    public static readonly Guid EspressoMartini = new("f0a5abdc-8d24-4e1d-ba66-40a491f8b249");
    public static readonly Guid BAndB = new("a1b6bced-9e35-4f2e-cb67-51b502a9c350");
    public static readonly Guid Penicillin = new("b2c7cdfe-0f46-4a3f-dc68-62c613b0d451");
    public static readonly Guid Bramble = new("c3d8deaf-1a57-4b4a-ed69-73d724c1e552");
    public static readonly Guid Bellini = new("d4e9efba-2b68-4c5b-fe70-84e835d2f653");
    public static readonly Guid Godfather = new("e5f0facb-3c79-4d6c-af71-95f946e3a754");
    public static readonly Guid GoldenDream = new("f6a1abdc-4d80-4e7d-ba72-06a057f4b855");
    public static readonly Guid Grasshopper = new("a7b2bced-5e91-4f8e-cb73-17b168a5c956");
    public static readonly Guid Hurricane = new("b8c3cdfe-6f02-4a9f-dc74-28c279b6d057");
    public static readonly Guid JapaneseSlipper = new("c9d4deaf-7a13-4b0a-ed75-39d380c7e158");
    public static readonly Guid LongIslandIcedTea = new("d0e5efba-8b24-4c1b-fe76-40e491d8f259");
    public static readonly Guid MaryPickford = new("e1f6facb-9c35-4d2c-af77-51f502e9a360");
    public static readonly Guid Mudslide = new("f2a7abdc-0d46-4e3d-ba78-62a613f0b461");
    public static readonly Guid RustyNail = new("a3b8bced-1e57-4f4e-cb79-73b724a1c562");
    public static readonly Guid SeaBreeze = new("b4c9cdfe-2f68-4a5f-dc80-84c835b2d663");
    public static readonly Guid TequilaSunrise = new("c5d0deaf-3a79-4b6a-ed81-95d946c3e764");
    public static readonly Guid WardEight = new("d6e1efba-4b80-4c7b-fe82-06e057d4f865");
    public static readonly Guid YellowBird = new("e7f2facb-5c91-4d8c-af83-17f168e5a966");
    public static readonly Guid Zombie = new("f8a3abdc-6d02-4e9d-ba84-28a279f6b067");
}
