// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using ErrorOr;
using MediatR;

/// <summary>
/// Handles the creation of a new cocktail in the system.
/// </summary>
/// <remarks>
/// This handler processes the CreateCocktailCommand and returns a Result containing
/// either the created cocktail information or validation errors.
/// </remarks>
public class CreateCocktailCommandHandler : IRequestHandler<CreateCocktailCommand, ErrorOr<CreateCocktailResult>>
{
    /// <summary>
    /// Processes the command to create a new cocktail.
    /// </summary>
    /// <param name="request">The command containing cocktail creation details.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing either:
    /// - A successful CreateCocktailResult with the created cocktail's details.
    /// - An Error if the operation fails or validation fails.
    /// </returns>
    public Task<ErrorOr<CreateCocktailResult>> Handle(CreateCocktailCommand request, CancellationToken cancellationToken)
    {
        // For now, just return a successful result with the input data
        var result = new CreateCocktailResult(
            request.Name,
            request.Description,
            request.RecipeId);

        return Task.FromResult<ErrorOr<CreateCocktailResult>>(result);
    }
}
