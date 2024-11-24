// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
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

    public async Task<IEnumerable<Cocktail>> GetAllAsync()
    {
        return await context.Cocktails.ToListAsync();
    }

    public async Task AddAsync(Cocktail entity)
    {
        var existingEntity = await context.Cocktails.Where(c => c.Id == entity.Id).FirstOrDefaultAsync();
        InfrastructureException.For<Cocktail>(existingEntity != null, "Cocktail entity with the same id already exists!");

        await context.Cocktails.AddAsync(entity);
    }

    public void Update(Cocktail entity)
    {
        var existingEntity = context.Cocktails.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Cocktails.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Cocktail>(existingEntity is null, "Cocktail entity to update does not exist!");

        context.Cocktails.Update(entity);
    }

    public void Delete(Cocktail entity)
    {
        var existingEntity = context.Cocktails.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Cocktails.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Cocktail>(existingEntity is null, "Cocktail entity to delete does not exist!");

        context.Cocktails.Remove(entity);
    }
}
