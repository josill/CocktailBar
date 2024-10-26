// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers;

using CocktailBar.Api.Controllers.Common;
using CocktailBar.Application.Cocktails.Commands.CreateCocktail;
using CocktailBar.Contracts.Cocktails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing cocktail-related operations.
/// </summary>
/// /// <param name="mediatr">The MediatR sender used to dispatch commands and queries.</param>
[Route("cocktails")]
public class CocktailsController(ISender mediatr) : ApiController
{
    /// <summary>
    /// Creates a new cocktail with the specified recipe.
    /// </summary>
    /// <param name="request">The cocktail creation request containing cocktail details.</param>
    /// <returns>Returns the created cocktail information.</returns>
    /// <response code="200">Returns the newly created cocktail.</response>
    /// <response code="400">If the request is invalid.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCocktail(CreateCocktailRequest request)
    {
        var command = new CreateCocktailCommand(request.Name, request.Description, Guid.Empty);
        var result = await mediatr.Send(command);

        return result.Match(
            cocktail => Created($"/cocktails/{cocktail.CocktailId}", cocktail), // TODO: Add the get endpoint.
            HandleErrors);
    }
}
