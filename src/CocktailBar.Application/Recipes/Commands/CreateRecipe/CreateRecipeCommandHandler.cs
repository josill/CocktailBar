// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Recipes.Common;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.Common.Errors;

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using ErrorOr;
using MediatR;

/// <summary>
/// Handles the creation of a new recipe in the system.
/// </summary>
/// <remarks>
/// This handler processes the CreateRecipeCommand and returns a Result containing
/// either the created recipe information or validation errors.
/// </remarks>
public class CreateRecipeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, ErrorOr<RecipeResult>>
{
    /// <summary>
    /// Processes the command to create a new recipe.
    /// </summary>
    /// <param name="request">The command containing recipe creation details.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing either:
    /// - A successful CreateRecipeResult with the created recipe's details.
    /// - An Error if the operation fails or validation fails.
    /// </returns>
    public async Task<ErrorOr<RecipeResult>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = Recipe.Create(request.Name, request.Instructions);

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Recipes.AddAsync(recipe);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            return Errors.Common.SomethingWentWrong("Error creating the recipe entity");
        }

        return RecipeResult.From(recipe);
    }
}
