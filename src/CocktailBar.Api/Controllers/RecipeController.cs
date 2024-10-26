// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers;

using CocktailBar.Api.Controllers.Common;
using CocktailBar.Application.Recipes.Commands.CreateRecipe;
using CocktailBar.Contracts.Recipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing cocktail recipes in the system.
/// Provides endpoints for creating, retrieving, updating, and deleting recipes.
/// </summary>
[Route("recipes")]
public class RecipesController(ISender mediatr) : ApiController
{
    /// <summary>
    /// Creates a new cocktail recipe in the system.
    /// </summary>
    /// <param name="request">The recipe creation request containing the name and instructions.</param>
    /// <returns>
    /// 201 Created with the created recipe and its location if successful.
    /// 400 Bad Request if the request is invalid or validation fails.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
    {
        var command = new CreateRecipeCommand(request.Name, request.Instructions);
        var result = await mediatr.Send(command);

        return result.Match(
            recipe => Created($"/recipes/{recipe.RecipeId}", recipe), // TODO: Add the get endpoint.
            HandleErrors);
    }
}
