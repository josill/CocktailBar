// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common.Base.Interfaces;

/// <summary>
/// Represents a generic interface for entities with an identifier.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public interface IEntity<out TId>
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    /// <value>
    /// The identifier of the entity.
    /// </value>
    TId Id { get; }
}
