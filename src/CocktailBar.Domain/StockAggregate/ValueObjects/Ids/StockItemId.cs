namespace CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

using CocktailBar.Domain.Common;

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