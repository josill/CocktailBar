using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail;

public class Ingredient : EntityWithMetadata<IngredientId>
{
    public StockItem Value { get; private set; }
    public Amount Amount { get; private set; }
    
    public Ingredient(IngredientId id) : base(id)
    {
    }
}