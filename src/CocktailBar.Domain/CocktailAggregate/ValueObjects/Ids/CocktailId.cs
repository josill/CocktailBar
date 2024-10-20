namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using CocktailBar.Domain.Common;

/// <summary>
/// Represents a unique identifier for a cocktail in the cocktail domain.
/// </summary>
public sealed class CocktailId : ValueObject<CocktailId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailId"/> class.
    /// </summary>
    /// <param name="value">The GUID value to use for this CocktailId.</param>
    /// <remarks>
    /// This constructor is private to enforce creation through the <see cref="CreateUnique"/> method.
    /// </remarks>
    private CocktailId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the underlying GUID value of the CocktailId.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new unique CocktailId.
    /// </summary>
    /// <returns>A new instance of <see cref="CocktailId"/> with a unique GUID value.</returns>
    public static CocktailId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}