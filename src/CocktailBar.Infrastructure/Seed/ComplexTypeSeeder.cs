using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;

namespace CocktailBar.Infrastructure.Seed;

public class ComplexTypeSeeder
{
    public static async Task Seed(IAppDbContext dbContext)
    {
        if (dbContext.RecipeIngredients.Any()) return;

        var recipeIngredients = new[]
        {
            RecipeIngredient.Create(
                RecipeIds.ClassicMartini,
                IngredientIds.GreyGooseVodka,
                Amount.Create(400, WeightUnit.Ml)
            ),
        };

        dbContext.RecipeIngredients.AddRange(recipeIngredients);
        await dbContext.SaveChangesAsync();
    }
}
