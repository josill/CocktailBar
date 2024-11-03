// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Repository;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;

/// <summary>
/// Implements the ICocktailsRepository interface to provide data access operations for cocktail entities.
/// </summary>
public class CocktailsRepository : ICocktailsRepository
{
    /// <summary>
    /// Retrieves a cocktail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the cocktail to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cocktail if found; otherwise, null.</returns>
    public Task<Cocktail?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all cocktails from the repository.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all cocktails.</returns>
    public Task<IEnumerable<Cocktail>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new cocktail to the repository.
    /// </summary>
    /// <param name="entity">The cocktail entity to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddAsync(Cocktail entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an existing cocktail in the repository.
    /// </summary>
    /// <param name="entity">The cocktail entity to update.</param>
    public void Update(Cocktail entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a cocktail from the repository.
    /// </summary>
    /// <param name="entity">The cocktail entity to delete.</param>
    public void Delete(Cocktail entity)
    {
        throw new NotImplementedException();
    }
}
