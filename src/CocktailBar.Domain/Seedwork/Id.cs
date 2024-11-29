// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Represents a strongly-typed identifier, wrapping a generic TId value to prevent primitive obsession.
/// This struct provides type safety to ensure GUIDs used as Foo identifiers cannot be mixed with other GUID identifiers.
/// </summary>
/// <typeparam name="TId">The type of the underlying identifier value.</typeparam>
public readonly struct Id<TId> : IEquatable<Id<TId>>
    where TId : IEquatable<TId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Id{TId}"/> struct with a specified value.
    /// </summary>
    /// <param name="value">Value of the identifier.</param>
    public Id(TId value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets identifier value.
    /// </summary>
    public TId Value { get; }

    /// <summary>
    /// Determines whether this instance and another specified Id object have the same value.
    /// </summary>
    /// <param name="other">The identifier to compare to this instance.</param>
    /// <returns>True if the value of the other parameter is the same as this instance; otherwise, false.</returns>
    public bool Equals(Id<TId> other) => Value.Equals(other.Value);

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Id<TId> other && Equals(other);
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Compares two identifiers for equality.
    /// </summary>
    /// <param name="left">The left identifier to compare.</param>
    /// <param name="right">The right identifier to compare.</param>
    /// <returns>True if the identifier are equal, false otherwise.</returns>
    public static bool operator ==(Id<TId> left, Id<TId> right) => left.Equals(right);

    /// <summary>
    /// Compares two identifier for equality.
    /// </summary>
    /// <param name="left">The left identifier to compare.</param>
    /// <param name="right">The right identifier to compare.</param>
    /// <returns>True if the identifier are equal, false otherwise.</returns>
    public static bool operator !=(Id<TId> left, Id<TId> right) => !(left == right);
}
