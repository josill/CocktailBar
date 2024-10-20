using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;
using CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail.Entities;

public class Ingredient : EntityWithMetadata<IngredientId>
{
    public StockItemId StockItemId { get; }
    public Amount Amount { get; }
    
    private Ingredient(StockItemId stockItemId, Amount amount) : base(IngredientId.CreateUnique())
    {
        StockItemId = stockItemId;
        Amount = amount;
    }

    private static Ingredient Create(StockItemId stockItemId, Amount amount) => new(stockItemId, amount);
}