// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Recipes.Common;
using CocktailBar.Domain.RecipeAggregate.Entities;
using CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Seedwork.Errors;
using MediatR;
using ErrorOr;

namespace CocktailBar.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRecipeQuery, ErrorOr<RecipeResult>>
{
    public async Task<ErrorOr<RecipeResult>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var recipe = await unitOfWork.Recipes.GetByIdAsync(new RecipeId(request.RecipeId));
            if (recipe is null) throw NotFoundException.For<Recipe>($"Recipe with the specified id: {request.RecipeId} not found!");

            var result = RecipeResult.From(recipe!);
            return result;
        }
        catch (Exception e)
        {
            throw SomethingWentWrongException.For<Recipe>($"Error retrieving the recipe entity: {e.Message}");
        }    
    }
}
