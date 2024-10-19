using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects.Ids;

public sealed class CocktailId : ValueObject<CocktailId>
{
    public Guid Value { get; }

    private CocktailId(Guid value)
    {
        Value = value;
    }

    public static CocktailId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}