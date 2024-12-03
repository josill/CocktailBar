// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Recipes.Common;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace CocktailBar.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRecipeQuery, ErrorOr<RecipeResult>>
{
    public async Task<ErrorOr<RecipeResult>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var recipe = await unitOfWork.Recipes.GetByIdAsync(RecipeId.From(request.RecipeId));
            DomainException.For<Recipe>(recipe == null, "Recipe with the specified id not found!");

            var result = RecipeResult.From(recipe!);
            return result;
        }
        catch (Exception e)
        {
            return Errors.Common.SomethingWentWrong(e.Message);
        }    }
}
