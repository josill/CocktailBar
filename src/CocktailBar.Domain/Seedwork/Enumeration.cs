using System.Reflection;

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for creating enumeration classes that are more type-safe and feature-rich than standard enums.
/// </summary>
public abstract class Enumeration : Entity<Guid>, IComparable
{
    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    public string Name { get; }

    #pragma warning disable SA1600
    protected Enumeration() {} // Private constructor for EF Core
    #pragma warning restore SA1600

    /// <summary>
    /// Initializes a new instance of the <see cref="Enumeration"/> class.
    /// </summary>
    /// <param name="id">The identifier for the enumeration.</param>
    /// <param name="name">The name of the enumeration.</param>
    protected Enumeration(Guid id, string name) : base(id) => Name = name;

    /// <summary>
    /// Returns the string representation of the enumeration.
    /// </summary>
    /// <returns>The name of the enumeration.</returns>
    public override string ToString() => Name;

    /// <summary>
    /// Gets all defined enumeration values for a specific enumeration type.
    /// </summary>
    /// <typeparam name="T">The type of enumeration to get values for.</typeparam>
    /// <returns>An IEnumerable containing all defined enumeration values.</returns>
    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                          BindingFlags.Static |
                          BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    /// <summary>
    /// Compares this enumeration with another object.
    /// </summary>
    /// <param name="other">The object to compare with this enumeration.</param>
    /// <returns>
    /// Less than zero if this value is less than the other value,
    /// zero if they are equal,
    /// or greater than zero if this value is greater than the other value.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when other is null.</exception>
    /// <exception cref="ArgumentException">Thrown when other is not an Enumeration.</exception>
    public int CompareTo(object? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        if (other is not Enumeration otherEnumeration)
            throw new ArgumentException("Object is not an Enumeration", nameof(other));

        return Id.CompareTo(otherEnumeration.Id);
    }

    /// <summary>
    /// Determines whether this enumeration equals another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current enumeration value.</param>
    /// <returns>true if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Enumeration other && Equals(other);
    }

    /// <summary>
    /// Returns a hash code for this enumeration.
    /// </summary>
    /// <returns>A hash code value that combines both the Name and Id.</returns>
    public override int GetHashCode() => HashCode.Combine(Name, Id);

    /// <summary>
    /// Determines whether this enumeration equals another enumeration.
    /// </summary>
    /// <param name="other">The enumeration to compare with the current enumeration.</param>
    /// <returns>true if the enumeration values are equal; otherwise, false.</returns>
    private bool Equals(Enumeration? other)
    {
        if (other is null) return false;
        return GetType() == other.GetType() && Id.Equals(other.Id);
    }
}
