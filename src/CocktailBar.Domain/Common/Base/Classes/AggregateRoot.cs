// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common.Base.Classes;

/// <summary>
/// Represents an abstract base class for aggregate roots in the domain model.
/// </summary>
/// <typeparam name="TId">The type of the aggregate root's identifier, which must be non-null.</typeparam>
/// <remarks>
/// An aggregate root is an entity that acts as the entry point to an aggregate in Domain-Driven Design.
/// It encapsulates and controls access to a cluster of related objects treated as a single unit for data changes.
/// </remarks>
public abstract class AggregateRoot<TId> : EntityWithMetadata<TId>
    where TId : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the aggregate root.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
    protected AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot() { }
}
