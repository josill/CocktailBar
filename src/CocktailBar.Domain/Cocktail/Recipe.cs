using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail;

public class Recipe : EntityWithMetadata<RecipeId>
{
    
    
    public Recipe(RecipeId id) : base(id)
    {
    }
}

public readonly record struct RecipeId(Guid Value);