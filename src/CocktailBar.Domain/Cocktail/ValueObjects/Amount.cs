using Ardalis.GuardClauses;
using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail;

public class Amount : ValueObject<Amount>
{
    public readonly decimal Value;
    public readonly AmountUnit Unit;

    public Amount(decimal value, AmountUnit unit)
    {
        Validate(value);
        Value = value;
        Unit = unit;
    }
    
    /// <summary>
    /// Validates the amount value using guard clauses.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <exception cref="MoreThanThreeDecimalPlacesInWeightValueException">Thrown when the value has more than two decimal places.</exception>
    /// <exception cref="WeightCannotBeNegativeException">Thrown when the value is negative.</exception>
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

/// <summary>
/// Represents the units of measurement for weight.
/// </summary>
public enum AmountUnit
{
    /// <summary>
    /// Weight in grams.
    /// </summary>
    G,

    /// <summary>
    /// Weight in kilograms.
    /// </summary>
    Kg,

    /// <summary>
    /// Weight in millilitres.
    /// </summary>
    Ml,
    
    /// <summary>
    /// Weight in litres.
    /// </summary>
    L
}

/// <summary>
/// Exception thrown when a weight value has more than two decimal places.
/// </summary>
public class MoreThanThreeDecimalPlacesInWeightValueException()
    : Exception("Weight value cannot have more than three decimal places.");

/// <summary>
/// Exception thrown when a weight value is negative.
/// </summary>
public class WeightCannotBeNegativeException() : Exception("Weight cannot be a negative value.");