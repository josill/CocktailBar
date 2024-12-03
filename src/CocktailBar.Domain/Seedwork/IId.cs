// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

public interface IId<out TId, TValue>
    where TId : IId<TId, TValue>
{
    public TValue Value { get; init; }

    /// <summary>
    /// Creates a new instance of the ID with a newly generated unique identifier.
    /// </summary>
    /// <returns>A new instance of the ID type with a unique value.</returns>
    public static abstract TId New();

    /// <summary>
    /// Creates an ID instance from an existing GUID value.
    /// </summary>
    /// <param name="id">The GUID value to create the ID from.</param>
    /// <returns>A new instance of the ID type containing the provided GUID value.</returns>
    public static abstract TId From(TValue id);
}

