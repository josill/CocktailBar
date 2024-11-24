// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Cocktails.Repository;

public class RecipeRepository(IAppDbContext context) : IRepository<Recipe, RecipeId>
{
    public async Task<Recipe?> GetByIdAsync(RecipeId id)
    {
        var entity = await context.Recipes.Where(c => c.Id == id).FirstOrDefaultAsync();

        return entity;
    }

    public Task<IEnumerable<Recipe>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Recipe entity)
    {
        var existingEntity = await context.Recipes.Where(c => c.Id == entity.Id).FirstOrDefaultAsync();
        // TODO: determine a suitable location for the error
        InfrastructureException.For<Cocktail>(existingEntity != null, "Recipe entity with the same id already exists!");

        await context.Recipes.AddAsync(entity);
    }

    public void Update(Recipe entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Recipe entity)
    {
        throw new NotImplementedException();
    }
}
