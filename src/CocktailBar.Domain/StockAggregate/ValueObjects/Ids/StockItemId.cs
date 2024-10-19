using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Stock.ValueObjects.Ids;

public class StockItemId : ValueObject<StockItemId>
{
    public Guid Value { get; }

    private StockItemId(Guid value)
    {
        Value = value;
    }

    public static StockItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}