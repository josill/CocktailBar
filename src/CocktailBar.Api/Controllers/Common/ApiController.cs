// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers.Common;

using CocktailBar.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

/// <summary>
/// Base controller for API endpoints, providing common error handling functionality.
/// </summary>
[ApiController]
public class ApiController : ControllerBase
{
    /// <summary>
    /// Handles a list of errors and returns an appropriate IActionResult.
    /// </summary>
    /// <param name="errors">The list of errors to handle.</param>
    /// <returns>An IActionResult representing the appropriate error response.</returns>
    protected IActionResult HandleErrors(List<Error> errors)
    {
        if (errors.Count == 0) return Problem();

        if (errors.TrueForAll(e => e.Type == ErrorType.Validation))
        {
            return CreateValidationProblem(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors[0]);
    }

    /// <summary>
    /// Creates an ObjectResult for a single error with the appropriate HTTP status code.
    /// </summary>
    /// <param name="error">The error to create a problem result for.</param>
    /// <returns>An ObjectResult representing the problem details.</returns>
    private ObjectResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    /// <summary>
    /// Creates a ValidationProblem result from a collection of errors.
    /// </summary>
    /// <param name="errors">The collection of errors to include in the validation problem.</param>
    /// <returns>An ActionResult representing the validation problem.</returns>
    private ActionResult CreateValidationProblem(IEnumerable<Error> errors)
    {
        var modelStateDict = new ModelStateDictionary();

        foreach (var e in errors)
        {
            modelStateDict.AddModelError(
                e.Code,
                e.Description);
        }

        return ValidationProblem(modelStateDict);
    }
}
