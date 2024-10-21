// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers.Common;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller responsible for handling global unhandled exceptions in the application.
/// </summary>
public class ErrorsController : ControllerBase
{
    /// <summary>
    /// Handles both GET and POST requests to the "/error" endpoint.
    /// This method is called when an unhandled exception occurs in the application.
    /// </summary>
    /// <returns>An IActionResult representing the error response.</returns>
    [HttpPost("/error")]
    [HttpGet("/error")]
    public IActionResult Error()
    {
        // Retrieve the exception that caused the error
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        // Return a Problem Details response with the exception message and a 500 status code
        return Problem(exception?.Message, statusCode: 500);
    }
}
