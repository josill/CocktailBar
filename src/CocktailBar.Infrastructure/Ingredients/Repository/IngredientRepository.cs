// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Ingredients.Repository;

public class IngredientRepository(IAppDbContext context) : IRepository<Ingredient, IngredientId>
{
    public async Task<Ingredient?> GetByIdAsync(IngredientId id)
    {
        var entity = await context.Ingredients.Where(c => c.Id == id).FirstOrDefaultAsync();
        return entity;
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await context.Ingredients.ToListAsync();
    }

    public async Task AddAsync(Ingredient entity)
    {
        var existingEntity = await context.Ingredients.Where(c => c.Id == entity.Id).FirstOrDefaultAsync();
        InfrastructureException.For<Ingredient>(existingEntity != null, "Ingredient entity with the same id already exists!");

        await context.Ingredients.AddAsync(entity);
    }

    public void Update(Ingredient entity)
    {
        var existingEntity = context.Ingredients.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Ingredients.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Ingredient>(existingEntity is null, "Ingredient entity to update does not exist!");

        context.Ingredients.Update(entity);
    }

    public void Delete(Ingredient entity)
    {
        var existingEntity = context.Ingredients.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Ingredients.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Ingredient>(existingEntity is null, "Ingredient entity to delete does not exist!");

        context.Ingredients.Remove(entity);
    }
}
