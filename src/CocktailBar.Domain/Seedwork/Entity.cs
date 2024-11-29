// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

using MediatR;

/// <summary>
/// Base class for domain entities with generic ID type.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Entity<TId>
{
    private TId _id = default!;

    /// <summary>
    /// Gets or sets the entity's identifier.
    /// </summary>
    public virtual TId Id
    {
        get => _id;
        protected set => _id = value;
    }

    /// <summary>
    /// Gets the collection of domain events.
    /// </summary>
    public List<INotification> DomainEvents { get; } = [];

    /// <summary>
    /// Adds a domain event to the entity.
    /// </summary>
    /// <param name="eventItem">The event to be added.</param>
    public void AddDomainEvent(INotification eventItem)
    {
        DomainEvents.Add(eventItem);
    }

    /// <summary>
    /// Removes a domain event from the entity.
    /// </summary>
    /// <param name="eventItem">The event to be removed.</param>
    public void RemoveDomainEvent(INotification eventItem)
    {
        DomainEvents.Remove(eventItem);
    }

    /// <summary>
    /// Checks if the entity is transient (not persisted to database).
    /// </summary>
    /// <returns>If the entity is persisted in transient.</returns>
    public bool IsTransient()
    {
        return EqualityComparer<TId>.Default.Equals(Id, default(TId));
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
        return obj.GetType() == this.GetType() && Equals((Entity<TId>)obj);
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
    private bool Equals(Entity<TId>? other)
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
    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two entities for inequality.
    /// </summary>
    /// <param name="left">The left entity to compare.</param>
    /// <param name="right">The right entity to compare.</param>
    /// <returns>True if the entities are not equal, false otherwise.</returns>
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !Equals(left, right);
    }
}
