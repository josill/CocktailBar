using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects.Ids;

public sealed class IngredientId(Guid value) : ValueObject<IngredientId>
{
    public Guid Value { get; } = value;

    private static IngredientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}