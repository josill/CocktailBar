// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Cocktails.Repository;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;

/// <summary>
/// Implements the ICocktailsRepository interface to provide data access operations for cocktail entities.
/// </summary>
public class CocktailsRepository(ICocktailsWriteContext cocktailsWrite, ICocktailsReadContext cocktailsRead) : ICocktailsRepository
{
    /// <summary>
    /// Retrieves a cocktail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the cocktail to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the cocktail if found; otherwise, null.</returns>
    public async Task<Cocktail?> GetByIdAsync(CocktailId id)
    {
        var entity = await cocktailsRead.Cocktails.Where(c => c.Id == id.Value).FirstOrDefaultAsync();

        return entity is null ? null : Cocktail.From(entity);
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
    public async Task AddAsync(Cocktail entity)
    {
        var existingEntity = await cocktailsRead.Cocktails.Where(c => c.Id == entity.Id.Value).FirstOrDefaultAsync();
        InfrastructureException.For<Cocktail>(existingEntity != null, "Cocktail entity with the same id already exists!");

        await cocktailsWrite.Cocktails.AddAsync(entity);
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
