// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Cocktails.Repository;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;

public class CocktailsRepository(IAppDbContext context) : IRepository<Cocktail, CocktailId>
{
    public async Task<Cocktail?> GetByIdAsync(CocktailId id)
    {
        var entity = await context.Cocktails.Where(c => c.Id == id).FirstOrDefaultAsync();

        return entity;
    }

    public Task<IEnumerable<Cocktail>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Cocktail entity)
    {
        var existingEntity = await context.Cocktails.Where(c => c.Id == entity.Id).FirstOrDefaultAsync();
        // TODO: determine a suitable location for the error
        InfrastructureException.For<Cocktail>(existingEntity != null, "Cocktail entity with the same id already exists!");

        await context.Cocktails.AddAsync(entity);
    }

    public void Update(Cocktail entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Cocktail entity)
    {
        throw new NotImplementedException();
    }
}
