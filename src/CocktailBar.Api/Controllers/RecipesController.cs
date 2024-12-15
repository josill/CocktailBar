// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Recipes.Queries.GetRecipe;

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
    /// Gets a recipe by the unique identifier.
    /// </summary>
    /// <param name="recipeId">The recipe unique identifier.</param>
    /// <returns>Returns the recipe information.</returns>
    [HttpGet("{recipeId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid recipeId)
    {
        var query = new GetRecipeQuery(recipeId);
        var result = await mediatr.Send(query);

        return result.Match(Ok, HandleErrors);
    }
    
    /// <summary>
    /// Creates a new cocktail recipe in the system.
    /// </summary>
    /// <param name="request">The recipe creation request containing the name and instructions.</param>
    /// <returns>Return the recipe information.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateRecipeRequest request)
    {
        var command = new CreateRecipeCommand(request.Name, request.Instructions);
        var result = await mediatr.Send(command);

        return result.Match(
            recipe => Created($"/recipes/{recipe.RecipeId}", recipe),
            HandleErrors);
    }
}
