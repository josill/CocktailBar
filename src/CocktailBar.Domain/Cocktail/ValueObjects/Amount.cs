using Ardalis.GuardClauses;
using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects;

public class Amount : ValueObject<Amount>
{
    public readonly decimal Value;
    public readonly AmountUnit Unit;

    private Amount(decimal value, AmountUnit unit)
    {
        Validate(value);
        Value = value;
        Unit = unit;
    }

    public static Amount Create(decimal value, AmountUnit unit) => new(value, unit);

    private static void Validate(decimal value)
    {
        Guard.Against.Requires<MoreThanThreeDecimalPlacesInWeightValueException>(value % 0.001m == 0);
        Guard.Against.Requires<WeightCannotBeNegativeException>(value >= 0);
    }
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
        yield return Unit;
    }
}