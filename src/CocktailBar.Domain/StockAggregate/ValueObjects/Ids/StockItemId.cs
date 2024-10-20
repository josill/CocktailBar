namespace CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

using CocktailBar.Domain.Common;

/// <summary>
/// Represents a unique identifier for stock items in the cocktail bar domain.
/// This class is immutable and follows the Value Object pattern.
/// </summary>
public class StockItemId : ValueObject<StockItemId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StockItemId"/> class.
    /// This constructor is private to enforce the use of <see cref="CreateUnique"/> for object creation.
    /// </summary>
    /// <param name="value">The GUID value to use as the identifier.</param>
    private StockItemId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the unique identifier value.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Creates a new <see cref="StockItemId"/> with a unique identifier.
    /// </summary>
    /// <returns>A new instance of <see cref="StockItemId"/> with a unique GUID.</returns>
    public static StockItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Specifies which properties should be used in equality comparisons and hashing.
    /// </summary>
    /// <returns>An IEnumerable of objects to be used for equality comparisons.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}