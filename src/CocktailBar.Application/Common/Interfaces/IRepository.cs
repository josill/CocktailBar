// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

/// <summary>
/// Defines operations for managing aggregate roots in the database.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Retrieves an aggregate by its primary key.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="id">The primary key value.</param>
    /// <returns>The aggregate if found; otherwise, null.</returns>
    Task<T?> GetByIdAsync<T>(object id) where T : class;

    /// <summary>
    /// Retrieves all aggregates of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <returns>A collection of all aggregates.</returns>
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class; // TODO: paging

    /// <summary>
    /// Adds a new aggregate to the database.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="aggregate">The aggregate to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync<T>(T aggregate) where T : class;

    /// <summary>
    /// Updates an existing aggregate in the database.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="aggregate">The aggregate to update.</param>
    void Update<T>(T aggregate) where T : class;

    /// <summary>
    /// Marks an aggregate for deletion from the database.
    /// </summary>
    /// <typeparam name="T">The type of aggregate root.</typeparam>
    /// <param name="aggregate">The aggregate to delete.</param>
    void Delete<T>(T aggregate) where T : class;
}
