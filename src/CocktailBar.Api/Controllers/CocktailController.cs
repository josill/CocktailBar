// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers;

using CocktailBar.Api.Controllers.Common;
using CocktailBar.Contracts.Cocktails;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing cocktail-related operations.
/// </summary>
[Route("cocktails")]
public class CocktailController : ApiController
{
    /// <summary>
    /// Creates a new cocktail with the specified recipe.
    /// </summary>
    /// <param name="request">The cocktail creation request containing cocktail details.</param>
    /// <param name="recipeId">The unique identifier of the recipe to associate with the cocktail.</param>
    /// <returns>Returns the created cocktail information.</returns>
    /// <response code="200">Returns the newly created cocktail.</response>
    /// <response code="400">If the request is invalid.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateCocktail(CreateCocktailRequest request, string recipeId)
    {
        return Ok(request);
    }
}
