// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common;

/// <summary>
/// Represents an abstract base class for entities with metadata, including a unique identifier and timestamps.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier, which must be non-null.</typeparam>
public abstract class EntityWithMetadata<TId> : IEntity<TId>, IEquatable<EntityWithMetadata<TId>>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityWithMetadata{TId}"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
    protected EntityWithMetadata(TId id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        Id = id;
    }

    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    /// <param name="left">The left entity to compare.</param>
    /// <param name="right">The right entity to compare.</param>
    /// <returns>true if the entities are equal; otherwise, false.</returns>
    public static bool operator ==(EntityWithMetadata<TId>? left, EntityWithMetadata<TId>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    /// <param name="left">The left entity to compare.</param>
    /// <param name="right">The right entity to compare.</param>
    /// <returns>true if the entities are not equal; otherwise, false.</returns>
    public static bool operator !=(EntityWithMetadata<TId>? left, EntityWithMetadata<TId>? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public TId Id { get; }

    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; } = DateTime.Now;

    /// <summary>
    /// Gets the date and time when the entity was last updated, or null if it hasn't been updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((EntityWithMetadata<TId>)obj);
    }

    /// <summary>
    /// Determines whether the specified entity is equal to the current entity.
    /// </summary>
    /// <param name="other">The entity to compare with the current entity.</param>
    /// <returns>true if the specified entity is equal to the current entity; otherwise, false.</returns>
    public bool Equals(EntityWithMetadata<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TId>.Default.Equals(Id, other.Id) && CreatedAt.Equals(other.CreatedAt) && Nullable.Equals(UpdatedAt, other.UpdatedAt);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }

    /// <summary>
    /// Updates the entity's UpdatedAt timestamp to the current UTC time.
    /// </summary>
    /// <remarks>
    /// This method is intended to be called by derived classes when the entity is modified.
    /// </remarks>
    protected virtual void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
