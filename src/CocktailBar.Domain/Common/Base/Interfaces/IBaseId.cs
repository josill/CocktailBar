// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common;

/// <summary>
/// Represents a generic interface for creating and managing strongly-typed IDs.
/// This interface enables type-safe ID creation and conversion while maintaining
/// type specificity across the domain model.
/// </summary>
/// <typeparam name="TId">
/// The specific ID type that implements this interface. This type parameter
/// enables self-referencing generic constraints for implementing types.
/// </typeparam>
public interface IBaseId<out TId>
    where TId : IBaseId<TId>
{
    /// <summary>
    /// Creates a new instance of the ID with a newly generated unique identifier.
    /// </summary>
    /// <returns>A new instance of the ID type with a unique value.</returns>
    static abstract TId New();

    /// <summary>
    /// Creates an ID instance from an existing GUID value.
    /// </summary>
    /// <param name="id">The GUID value to create the ID from.</param>
    /// <returns>A new instance of the ID type containing the provided GUID value.</returns>
    static abstract TId From(Guid id);
}
