// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for domain aggregates with generic ID type.
/// </summary>
/// <typeparam name="TId">The type of the aggregate's identifier.</typeparam>
public abstract class Aggregate<TId>
{
    #pragma warning disable SA1600
    protected Aggregate() {} // Protected constructor for inheriting classes to use with EF Core
    #pragma warning restore SA1600

    /// <summary>
    /// Gets the unique identifier of the aggregate.
    /// </summary>
    public TId Id { get; } = default!;

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Aggregate<TId>)obj);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return Id is null ? 0 : EqualityComparer<TId>.Default.GetHashCode(Id);
    }

    /// <summary>
    /// Determines whether the specified aggregate is equal to the current aggregate.
    /// </summary>
    /// <param name="other">The aggregate to compare with the current aggregate.</param>
    /// <returns>true if the specified aggregate is equal to the current aggregate; otherwise, false.</returns>
    private bool Equals(Aggregate<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <summary>
    /// Compares two aggregates for equality.
    /// </summary>
    /// <param name="left">The left aggregate to compare.</param>
    /// <param name="right">The right aggregate to compare.</param>
    /// <returns>True if the aggregates are equal, false otherwise.</returns>
    public static bool operator ==(Aggregate<TId>? left, Aggregate<TId>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two aggregates for inequality.
    /// </summary>
    /// <param name="left">The left aggregate to compare.</param>
    /// <param name="right">The right aggregate to compare.</param>
    /// <returns>True if the aggregates are not equal, false otherwise.</returns>
    public static bool operator !=(Aggregate<TId>? left, Aggregate<TId>? right)
    {
        return !Equals(left, right);
    }
}
