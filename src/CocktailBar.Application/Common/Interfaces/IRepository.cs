// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

/// <summary>
/// Defines a generic repository pattern interface for entity operations.
/// Provides basic CRUD (Create, Read, Update, Delete) operations for entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity this repository handles. Must be a reference type.</typeparam>
/// <typeparam name="TId">The type of entity id this repository handles. Must be a reference type.</typeparam>
public interface IRepository<TEntity, in TId>
    where TEntity : class
    where TId : class
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
    Task<TEntity?> GetByIdAsync(TId id);

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
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add to the repository.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method only stages the entity for insertion.
    /// The actual database insertion occurs when the unit of work commits the transaction.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity with updated values.</param>
    /// <remarks>
    /// This method only stages the entity for update.
    /// The actual database update occurs when the unit of work commits the transaction.
    /// The entity being updated must exist in the repository and be tracked by the context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    void Update(TEntity entity);

    /// <summary>
    /// Marks an entity for deletion from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <remarks>
    /// This method only stages the entity for deletion.
    /// The actual database deletion occurs when the unit of work commits the transaction.
    /// The entity being deleted must exist in the repository and be tracked by the context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
    void Delete(TEntity entity);
}
