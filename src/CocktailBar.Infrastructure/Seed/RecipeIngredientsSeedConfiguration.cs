using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Seed;

public class RecipeIngredientsSeedConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasData(GetSeedData());
    }

    public static IEnumerable<RecipeIngredient> GetSeedData()
    {
        return
        [
            // Classic Martini
            RecipeIngredient.Create(
                new RecipeIngredientId(Guid.NewGuid()),
                RecipeIds.ClassicMartini,
                IngredientIds.GreyGooseVodka,
                Amount.Create(60, WeightUnit.Ml)
            ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.ClassicMartini),
            //     new IngredientId(IngredientIds.DryVermouth),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.ClassicMartini),
            //     new IngredientId(IngredientIds.Olives),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Manhattan
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Manhattan),
            //     new IngredientId(IngredientIds.RittenhouseRye),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Manhattan),
            //     new IngredientId(IngredientIds.SweetVermouth),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Manhattan),
            //     new IngredientId(IngredientIds.AngosturaBitters),
            //     Amount.Create(2, WeightUnit.Dash)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Manhattan),
            //     new IngredientId(IngredientIds.MaraschinoCherries),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Margarita
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Margarita),
            //     new IngredientId(IngredientIds.BlancoTequila),
            //     Amount.Create(50, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Margarita),
            //     new IngredientId(IngredientIds.Cointreau),
            //     Amount.Create(20, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Margarita),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Margarita),
            //     new IngredientId(IngredientIds.AgaveNectar),
            //     Amount.Create(10, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Margarita),
            //     new IngredientId(IngredientIds.Salt),
            //     Amount.Create(2, WeightUnit.G)
            // ),
            //
            // // Negroni
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Negroni),
            //     new IngredientId(IngredientIds.TanquerayGin),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Negroni),
            //     new IngredientId(IngredientIds.Campari),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Negroni),
            //     new IngredientId(IngredientIds.SweetVermouth),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Negroni),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Old Fashioned
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.OldFashioned),
            //     new IngredientId(IngredientIds.MakersMark),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.OldFashioned),
            //     new IngredientId(IngredientIds.Sugar),
            //     Amount.Create(5, WeightUnit.G)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.OldFashioned),
            //     new IngredientId(IngredientIds.AngosturaBitters),
            //     Amount.Create(3, WeightUnit.Dash)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.OldFashioned),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Moscow Mule
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MoscowMule),
            //     new IngredientId(IngredientIds.GreyGooseVodka),
            //     Amount.Create(50, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MoscowMule),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(20, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MoscowMule),
            //     new IngredientId(IngredientIds.GingerBeer),
            //     Amount.Create(100, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MoscowMule),
            //     new IngredientId(IngredientIds.FreshMint),
            //     Amount.Create(1, WeightUnit.Sprig)
            // ),
            //
            // // Mojito
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Mojito),
            //     new IngredientId(IngredientIds.WhiteRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Mojito),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Mojito),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(20, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Mojito),
            //     new IngredientId(IngredientIds.FreshMint),
            //     Amount.Create(8, WeightUnit.Leaves)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Mojito),
            //     new IngredientId(IngredientIds.ClubSoda),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            //
            // // Daiquiri
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Daiquiri),
            //     new IngredientId(IngredientIds.WhiteRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Daiquiri),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Daiquiri),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            //
            // // Whiskey Sour
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiskeySour),
            //     new IngredientId(IngredientIds.BuffaloTrace),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiskeySour),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiskeySour),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiskeySour),
            //     new IngredientId(IngredientIds.EggWhite),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Mai Tai
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.DarkRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.OrangeCuracao),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.OrgatSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.OverproofRum),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.FreshMint),
            //     Amount.Create(1, WeightUnit.Sprig)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MaiTai),
            //     new IngredientId(IngredientIds.LimeWedge),
            //     Amount.Create(0.25m, WeightUnit.Piece)
            // ),
            //
            // // Cosmopolitan
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Cosmopolitan),
            //     new IngredientId(IngredientIds.CitrusVodka),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Cosmopolitan),
            //     new IngredientId(IngredientIds.CranberryJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Cosmopolitan),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Cosmopolitan),
            //     new IngredientId(IngredientIds.TripleSec),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Cosmopolitan),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // French 75
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.French75),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.French75),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(22, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.French75),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.French75),
            //     new IngredientId(IngredientIds.LemonPeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Gimlet
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Gimlet),
            //     new IngredientId(IngredientIds.HendricksGin),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Gimlet),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Gimlet),
            //     new IngredientId(IngredientIds.LimeWedge),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Dark 'n' Stormy
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.DarkNStormy),
            //     new IngredientId(IngredientIds.DarkRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.DarkNStormy),
            //     new IngredientId(IngredientIds.GingerBeer),
            //     Amount.Create(120, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.DarkNStormy),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.DarkNStormy),
            //     new IngredientId(IngredientIds.LimeWedge),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Tom Collins
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.TomCollins),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.TomCollins),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.TomCollins),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.TomCollins),
            //     new IngredientId(IngredientIds.ClubSoda),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.TomCollins),
            //     new IngredientId(IngredientIds.MaraschinoCherries),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Boulevardier
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Boulevardier),
            //     new IngredientId(IngredientIds.BuffaloTrace),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Boulevardier),
            //     new IngredientId(IngredientIds.Campari),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Boulevardier),
            //     new IngredientId(IngredientIds.SweetVermouth),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Boulevardier),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Paloma
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Paloma),
            //     new IngredientId(IngredientIds.BlancoTequila),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Paloma),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Paloma),
            //     new IngredientId(IngredientIds.GrapefruitJuice),
            //     Amount.Create(120, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Paloma),
            //     new IngredientId(IngredientIds.ClubSoda),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Paloma),
            //     new IngredientId(IngredientIds.Salt),
            //     Amount.Create(2, WeightUnit.G)
            // ),
            //
            // // Mint Julep
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MintJulep),
            //     new IngredientId(IngredientIds.MakersMark),
            //     Amount.Create(75, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MintJulep),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.MintJulep),
            //     new IngredientId(IngredientIds.FreshMint),
            //     Amount.Create(8, WeightUnit.Leaves)
            // ),
            //
            // // Vesper
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Vesper),
            //     new IngredientId(IngredientIds.TanquerayGin),
            //     Amount.Create(90, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Vesper),
            //     new IngredientId(IngredientIds.GreyGooseVodka),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Vesper),
            //     new IngredientId(IngredientIds.LilletBlanc),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Vesper),
            //     new IngredientId(IngredientIds.LemonPeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Singapore Sling
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.MaraschinoLiqueur),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.Cointreau),
            //     Amount.Create(7.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.PineappleJuice),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.ClubSoda),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.SingaporeSling),
            //     new IngredientId(IngredientIds.MaraschinoCherries),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Aviation
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Aviation),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Aviation),
            //     new IngredientId(IngredientIds.MaraschinoLiqueur),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Aviation),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Aviation),
            //     new IngredientId(IngredientIds.MaraschinoCherries),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Pisco Sour
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.PiscoSour),
            //     new IngredientId(IngredientIds.Pisco),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.PiscoSour),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.PiscoSour),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.PiscoSour),
            //     new IngredientId(IngredientIds.EggWhite),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.PiscoSour),
            //     new IngredientId(IngredientIds.AngosturaBitters),
            //     Amount.Create(3, WeightUnit.Dash)
            // ),
            //
            // // Last Word
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.LastWord),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.LastWord),
            //     new IngredientId(IngredientIds.GreenChartreuse),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.LastWord),
            //     new IngredientId(IngredientIds.MaraschinoLiqueur),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.LastWord),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            //
            // // Sazerac
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sazerac),
            //     new IngredientId(IngredientIds.RittenhouseRye),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sazerac),
            //     new IngredientId(IngredientIds.Sugar),
            //     Amount.Create(1, WeightUnit.Piece) // Sugar cube
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sazerac),
            //     new IngredientId(IngredientIds.PeychaudsBitters),
            //     Amount.Create(4, WeightUnit.Dash)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sazerac),
            //     new IngredientId(IngredientIds.Absinthe),
            //     Amount.Create(20, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sazerac),
            //     new IngredientId(IngredientIds.LemonPeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Blood and Sand
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BloodAndSand),
            //     new IngredientId(IngredientIds.BlendedScotch),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BloodAndSand),
            //     new IngredientId(IngredientIds.MaraschinoLiqueur),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BloodAndSand),
            //     new IngredientId(IngredientIds.SweetVermouth),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BloodAndSand),
            //     new IngredientId(IngredientIds.OrangeJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BloodAndSand),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // French Martini
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.FrenchMartini),
            //     new IngredientId(IngredientIds.GreyGooseVodka),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.FrenchMartini),
            //     new IngredientId(IngredientIds.PineappleJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.FrenchMartini),
            //     new IngredientId(IngredientIds.Chambord),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.FrenchMartini),
            //     new IngredientId(IngredientIds.LemonPeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Corpse Reviver #2
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.LilletBlanc),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.TripleSec),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.Absinthe),
            //     Amount.Create(1, WeightUnit.Dash)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.CorpseReviver2),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Irish Coffee
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.IrishCoffee),
            //     new IngredientId(IngredientIds.IrishWhiskey),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.IrishCoffee),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.IrishCoffee),
            //     new IngredientId(IngredientIds.Coffee),
            //     Amount.Create(120, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.IrishCoffee),
            //     new IngredientId(IngredientIds.WhippedCream),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.IrishCoffee),
            //     new IngredientId(IngredientIds.Nutmeg),
            //     Amount.Create(1, WeightUnit.Dash)
            // ),
            //
            // // White Russian
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiteRussian),
            //     new IngredientId(IngredientIds.GreyGooseVodka),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiteRussian),
            //     new IngredientId(IngredientIds.Kahlua),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiteRussian),
            //     new IngredientId(IngredientIds.Cream),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.WhiteRussian),
            //     new IngredientId(IngredientIds.Cinnamon),
            //     Amount.Create(1, WeightUnit.Dash)
            // ),
            //
            // // Sidecar
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sidecar),
            //     new IngredientId(IngredientIds.Cognac),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sidecar),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sidecar),
            //     new IngredientId(IngredientIds.TripleSec),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sidecar),
            //     new IngredientId(IngredientIds.Sugar),
            //     Amount.Create(5, WeightUnit.G)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Sidecar),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Espresso Martini
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.EspressoMartini),
            //     new IngredientId(IngredientIds.BelvedereVodka),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.EspressoMartini),
            //     new IngredientId(IngredientIds.Kahlua),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.EspressoMartini),
            //     new IngredientId(IngredientIds.FreshEspresso),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.EspressoMartini),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.EspressoMartini),
            //     new IngredientId(IngredientIds.CoffeeBeans),
            //     Amount.Create(3, WeightUnit.Piece)
            // ),
            //
            // // B&B
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BAndB),
            //     new IngredientId(IngredientIds.Benedictine),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.BAndB),
            //     new IngredientId(IngredientIds.Cognac),
            //     Amount.Create(45, WeightUnit.Ml)
            // ),
            //
            // // Penicillin
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Penicillin),
            //     new IngredientId(IngredientIds.BlendedScotch),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Penicillin),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Penicillin),
            //     new IngredientId(IngredientIds.HoneySyrup),
            //     Amount.Create(22.5m, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Penicillin),
            //     new IngredientId(IngredientIds.FreshGinger),
            //     Amount.Create(3, WeightUnit.Piece)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Penicillin),
            //     new IngredientId(IngredientIds.SingleMaltScotch),
            //     Amount.Create(7.5m, WeightUnit.Ml)
            // ),
            //
            // // Bramble
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.PlymouthGin),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.SimpleSyrup),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.CremeDeCassis),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.FreshBerries),
            //     Amount.Create(3, WeightUnit.Piece)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bramble),
            //     new IngredientId(IngredientIds.LimeWedge),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Bellini
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bellini),
            //     new IngredientId(IngredientIds.Prosecco),
            //     Amount.Create(120, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bellini),
            //     new IngredientId(IngredientIds.PeachPuree),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Bellini),
            //     new IngredientId(IngredientIds.FreshPeach),
            //     Amount.Create(1, WeightUnit.Slice)
            // ),
            //
            // // Godfather
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Godfather),
            //     new IngredientId(IngredientIds.SingleMaltScotch),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Godfather),
            //     new IngredientId(IngredientIds.Amaretto),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Godfather),
            //     new IngredientId(IngredientIds.OrangePeel),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Golden Dream
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.GoldenDream),
            //     new IngredientId(IngredientIds.TripleSec),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.GoldenDream),
            //     new IngredientId(IngredientIds.Galliano),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.GoldenDream),
            //     new IngredientId(IngredientIds.OrangeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.GoldenDream),
            //     new IngredientId(IngredientIds.FreshCream),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            //
            // // Grasshopper
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Grasshopper),
            //     new IngredientId(IngredientIds.CremeDeMenthe),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Grasshopper),
            //     new IngredientId(IngredientIds.CremeDeCacao),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Grasshopper),
            //     new IngredientId(IngredientIds.FreshCream),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Grasshopper),
            //     new IngredientId(IngredientIds.FreshMint),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Hurricane
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.DarkRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.WhiteRum),
            //     Amount.Create(60, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.OrangeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.FreshLimeJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.PassionFruitSyrup),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.Grenadine),
            //     Amount.Create(15, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.FreshOrange),
            //     Amount.Create(1, WeightUnit.Slice)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.Hurricane),
            //     new IngredientId(IngredientIds.MaraschinoCherries),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Japanese Slipper
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.JapaneseSlipper),
            //     new IngredientId(IngredientIds.Midori),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.JapaneseSlipper),
            //     new IngredientId(IngredientIds.TripleSec),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.JapaneseSlipper),
            //     new IngredientId(IngredientIds.FreshLemonJuice),
            //     Amount.Create(30, WeightUnit.Ml)
            // ),
            // RecipeIngredientsAggregate.Create(
            //     new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //     new RecipeId(RecipeIds.JapaneseSlipper),
            //     new IngredientId(IngredientIds.HoneydewMelon),
            //     Amount.Create(1, WeightUnit.Piece)
            // ),
            //
            // // Long Island Iced Tea
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.GreyGooseVodka),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.TanquerayGin),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.WhiteRum),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.BlancoTequila),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.TripleSec),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.FreshLemonJuice),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.SimpleSyrup),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.Cola),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.LongIslandIcedTea),
            //         new IngredientId(IngredientIds.FreshLemon),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Mary Pickford
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.MaryPickford),
            //         new IngredientId(IngredientIds.WhiteRum),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.MaryPickford),
            //         new IngredientId(IngredientIds.PineappleJuice),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.MaryPickford),
            //         new IngredientId(IngredientIds.MaraschinoLiqueur),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.MaryPickford),
            //         new IngredientId(IngredientIds.Grenadine),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.MaryPickford),
            //         new IngredientId(IngredientIds.MaraschinoCherries),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Mudslide
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Mudslide),
            //         new IngredientId(IngredientIds.GreyGooseVodka),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Mudslide),
            //         new IngredientId(IngredientIds.Kahlua),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Mudslide),
            //         new IngredientId(IngredientIds.BaileysIrishCream),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //
            //     // Rusty Nail
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.RustyNail),
            //         new IngredientId(IngredientIds.BlendedScotch),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.RustyNail),
            //         new IngredientId(IngredientIds.Drambuie),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.RustyNail),
            //         new IngredientId(IngredientIds.LemonPeel),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Sea Breeze
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.SeaBreeze),
            //         new IngredientId(IngredientIds.GreyGooseVodka),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.SeaBreeze),
            //         new IngredientId(IngredientIds.CranberryJuice),
            //         Amount.Create(90, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.SeaBreeze),
            //         new IngredientId(IngredientIds.GrapefruitJuice),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.SeaBreeze),
            //         new IngredientId(IngredientIds.LimeWedge),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Tequila Sunrise
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.TequilaSunrise),
            //         new IngredientId(IngredientIds.BlancoTequila),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.TequilaSunrise),
            //         new IngredientId(IngredientIds.OrangeJuice),
            //         Amount.Create(120, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.TequilaSunrise),
            //         new IngredientId(IngredientIds.Grenadine),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.TequilaSunrise),
            //         new IngredientId(IngredientIds.FreshOrange),
            //         Amount.Create(1, WeightUnit.Slice)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.TequilaSunrise),
            //         new IngredientId(IngredientIds.MaraschinoCherries),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Ward Eight
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.RittenhouseRye),
            //         Amount.Create(60, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.FreshLemonJuice),
            //         Amount.Create(22.5m, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.OrangeJuice),
            //         Amount.Create(22.5m, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.Grenadine),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.FreshOrange),
            //         Amount.Create(1, WeightUnit.Slice)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.WardEight),
            //         new IngredientId(IngredientIds.MaraschinoCherries),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Yellow Bird
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.YellowBird),
            //         new IngredientId(IngredientIds.WhiteRum),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.YellowBird),
            //         new IngredientId(IngredientIds.Galliano),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.YellowBird),
            //         new IngredientId(IngredientIds.TripleSec),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.YellowBird),
            //         new IngredientId(IngredientIds.FreshLimeJuice),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.YellowBird),
            //         new IngredientId(IngredientIds.LimeWedge),
            //         Amount.Create(1, WeightUnit.Piece)
            //     ),
            //
            //     // Zombie
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.WhiteRum),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.GoldRum),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.DarkRum),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.FreshLimeJuice),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.PineappleJuice),
            //         Amount.Create(30, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.Grenadine),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.SimpleSyrup),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.OverproofRum),
            //         Amount.Create(15, WeightUnit.Ml)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.FreshMint),
            //         Amount.Create(1, WeightUnit.Sprig)
            //     ),
            //     RecipeIngredientsAggregate.Create(
            //         new RecipeIngredientsAggregateId(Guid.NewGuid()),
            //         new RecipeId(RecipeIds.Zombie),
            //         new IngredientId(IngredientIds.MaraschinoCherries),
            //         Amount.Create(1, WeightUnit.Piece)
            //     )
        ];
    }
}
