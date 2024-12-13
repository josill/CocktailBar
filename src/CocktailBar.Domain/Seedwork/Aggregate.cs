// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for domain entities with generic ID type.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Aggregate<TId>
{
    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public TId Id { get; } = default!;

    protected Aggregate() {}
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Aggregate{TId}"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
    protected Aggregate(TId id)
    {
        Id = id;
    }

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
    /// Determines whether the specified entity is equal to the current entity.
    /// </summary>
    /// <param name="other">The entity to compare with the current entity.</param>
    /// <returns>true if the specified entity is equal to the current entity; otherwise, false.</returns>
    private bool Equals(Aggregate<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <summary>
    /// Compares two entities for equality.
    /// </summary>
    /// <param name="left">The left entity to compare.</param>
    /// <param name="right">The right entity to compare.</param>
    /// <returns>True if the entities are equal, false otherwise.</returns>
    public static bool operator ==(Aggregate<TId>? left, Aggregate<TId>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two entities for inequality.
    /// </summary>
    /// <param name="left">The left entity to compare.</param>
    /// <param name="right">The right entity to compare.</param>
    /// <returns>True if the entities are not equal, false otherwise.</returns>
    public static bool operator !=(Aggregate<TId>? left, Aggregate<TId>? right)
    {
        return !Equals(left, right);
    }
}
