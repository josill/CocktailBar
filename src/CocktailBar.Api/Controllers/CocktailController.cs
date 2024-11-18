// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Queries.GetCocktail;

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
    /// Gets a new cocktail by the id.
    /// </summary>
    /// <param name="cocktailId">The cocktail id.</param>
    /// <returns>Returns the cocktail information.</returns>
    [HttpGet("{cocktailId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid cocktailId)
    {
        var command = new GetCocktailQuery(cocktailId);
        var result = await mediatr.Send(command);

        return result.Match(
            Ok,
            HandleErrors);
    }

    /// <summary>
    /// Creates a new cocktail with the specified recipe.
    /// </summary>
    /// <param name="request">The cocktail creation request containing cocktail details.</param>
    /// <returns>Returns the created cocktail information.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateCocktailRequest request)
    {
        var command = new CreateCocktailCommand(request.Name, request.Description, request.RecipeId);
        var result = await mediatr.Send(command);

        return result.Match(
            cocktail => Created($"/cocktails/{cocktail.CocktailId}", cocktail), // TODO: Add the get endpoint.
            HandleErrors);
    }
}
