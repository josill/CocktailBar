// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Recipes.Common;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Exceptions;

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using ErrorOr;
using MediatR;

public class CreateRecipeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, ErrorOr<RecipeResult>>
{
    public async Task<ErrorOr<RecipeResult>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = RecipeAggregate.Create(request.Name, request.Instructions);

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Recipes.AddAsync(recipe);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw SomethingWentWrongException.For<RecipeAggregate>($"Error creating the recipe entity: {e.Message}");
        }

        return RecipeResult.From(recipe);
    }
}
