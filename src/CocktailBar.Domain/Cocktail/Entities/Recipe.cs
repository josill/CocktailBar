using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail;

public class Recipe : EntityWithMetadata<RecipeId>
{
    
    
    public Recipe(RecipeId id) : base(id)
    {
    }
}