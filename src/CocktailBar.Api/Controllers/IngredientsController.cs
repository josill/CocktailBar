using CocktailBar.Api.Controllers.Common;
using CocktailBar.Application.Ingredients.Queries.FindIngredients;
using CocktailBar.Contracts.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CocktailBar.Api.Controllers;

[Route("ingredients")]
public class IngredientsController(ISender mediatr) : ApiController
{
    /// <summary>
    /// Find ingredients.
    /// </summary>
    /// <param name="request">Paginated find ingredients request.</param>
    /// <returns>Returns a paginated result of ingredients.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Find([FromQuery] FindIngredientsRequest request)
    {
        var query = new FindIngredientsQuery(request.Page, request.PageSize);
        var result = await mediatr.Send(query);

        return result.Match(Ok, HandleErrors);
    }
}
