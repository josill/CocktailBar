using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;
using CocktailBar.Domain.Stock.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail.Entities;

public class Ingredient : EntityWithMetadata<IngredientId>
{
    public StockItemId StockItemId { get; private set; }
    public Amount Amount { get; private set; }
    
    public Ingredient(StockItemId stockItemId, Amount amount) : base(IngredientId.CreateUnique())
    {
        StockItemId = stockItemId;
        Amount = amount;
    }
}