// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Recipes.Repository;

public class RecipeRepository(IAppDbContext context) : IRepository<Recipe, RecipeId>
{
    public async Task<Recipe?> GetByIdAsync(RecipeId id)
    {
        var entity = await context.Recipes.Where(c => c.Id == id).FirstOrDefaultAsync();
        return entity;
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await context.Recipes.ToListAsync();
    }

    public async Task AddAsync(Recipe entity)
    {
        var existingEntity = await context.Recipes.Where(c => c.Id == entity.Id).FirstOrDefaultAsync();
        InfrastructureException.For<Recipe>(existingEntity != null, "Recipe entity with the same id already exists!");

        await context.Recipes.AddAsync(entity);
    }

    public void Update(Recipe entity)
    {
        var existingEntity = context.Recipes.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Recipes.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Recipe>(existingEntity is null, "Recipe entity to update does not exist!");

        context.Recipes.Update(entity);
    }

    public void Delete(Recipe entity)
    {
        var existingEntity = context.Recipes.Local.FirstOrDefault(c => c.Id == entity.Id) 
                             ?? context.Recipes.FirstOrDefault(c => c.Id == entity.Id);
           
        InfrastructureException.For<Recipe>(existingEntity is null, "Recipe entity to delete does not exist!");

        context.Recipes.Remove(entity);
    }
}
