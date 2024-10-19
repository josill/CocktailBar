using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects.Ids;

public sealed class IngredientId : ValueObject<IngredientId>
{
    public Guid Value { get; }

    private IngredientId(Guid value)
    {
        Value = value;
    }
    
    public static IngredientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}