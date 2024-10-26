// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

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
public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<CreateRecipeResult>>
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
    public Task<ErrorOr<CreateRecipeResult>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        // For now, just return a successful result with the input data
        var result = new CreateRecipeResult(
            Guid.Empty,
            request.Name,
            request.Instructions);

        return Task.FromResult<ErrorOr<CreateRecipeResult>>(result);
    }
}
