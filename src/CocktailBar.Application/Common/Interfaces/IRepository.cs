// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

/// <summary>
/// Defines a generic repository pattern interface for entity operations.
/// Provides basic CRUD (Create, Read, Update, Delete) operations for entities.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the entity if found; otherwise, null.
    /// </returns>
    /// <remarks>
    /// This method is typically used for retrieving a single entity when its ID is known.
    /// Returns null if no entity is found with the specified ID.
    /// </remarks>
    Task<T?> GetByIdAsync<T>(object id) where T : class;

    /// <summary>
    /// Retrieves all entities of type TEntity from the repository asynchronously.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of all entities.
    /// Returns an empty collection if no entities exist.
    /// </returns>
    /// <remarks>
    /// Use this method with caution when dealing with large datasets.
    /// Consider implementing pagination for large collections.
    /// </remarks>
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class; // TODO: paging

    /// <summary>
    /// Adds a new aggregate to the repository asynchronously.
    /// </summary>
    /// <param name="aggregate">The aggregate to add to the repository.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method only stages the entity for insertion.
    /// The actual database insertion occurs when the unit of work commits the transaction.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    Task AddAsync<T>(T aggregate) where T : class;

    /// <summary>
    /// Updates an existing aggregate in the repository.
    /// </summary>
    /// <param name="aggregate">The aggregate with updated values.</param>
    /// <remarks>
    /// This method only stages the entity for update.
    /// The actual database update occurs when the unit of work commits the transaction.
    /// The entity being updated must exist in the repository and be tracked by the context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    void Update<T>(T aggregate) where T : class;

    /// <summary>
    /// Marks an aggregate for deletion from the repository.
    /// </summary>
    /// <param name="aggregate">The entity to delete.</param>
    /// <remarks>
    /// This method only stages the entity for deletion.
    /// The actual database deletion occurs when the unit of work commits the transaction.
    /// The entity being deleted must exist in the repository and be tracked by the context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    void Delete<T>(T aggregate) where T : class;
}
