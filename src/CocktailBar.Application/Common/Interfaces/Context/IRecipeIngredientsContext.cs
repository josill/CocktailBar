using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IRecipeIngredientsContext : IDisposable
{
    DbSet<RecipeIngredientAggregate> RecipeIngredients { get; }
}
