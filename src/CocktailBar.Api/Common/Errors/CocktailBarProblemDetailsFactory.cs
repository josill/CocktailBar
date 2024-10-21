// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Common.Errors;

using CocktailBar.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

/// <summary>
/// Custom implementation of ProblemDetailsFactory for the CocktailBar API.
/// This class is responsible for creating ProblemDetails and ValidationProblemDetails
/// objects with custom behavior specific to the CocktailBar application.
/// </summary>
public class CocktailBarProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailBarProblemDetailsFactory"/> class.
    /// </summary>
    /// <param name="options">The API behavior options.</param>
    public CocktailBarProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options.Value;
    }

    /// <summary>
    /// Creates a ProblemDetails object based on the provided parameters and HTTP context.
    /// </summary>
    /// <param name="httpContext">The HttpContext for the current request.</param>
    /// <param name="statusCode">The HTTP status code for the problem.</param>
    /// <param name="title">The title of the problem.</param>
    /// <param name="type">The type of the problem.</param>
    /// <param name="detail">Details about the problem.</param>
    /// <param name="instance">The instance of the problem.</param>
    /// <returns>A ProblemDetails object representing the problem.</returns>
    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    /// <summary>
    /// Creates a ValidationProblemDetails object based on the provided parameters and model state dictionary.
    /// </summary>
    /// <param name="httpContext">The HttpContext for the current request.</param>
    /// <param name="modelStateDictionary">The ModelStateDictionary containing validation errors.</param>
    /// <param name="statusCode">The HTTP status code for the validation problem.</param>
    /// <param name="title">The title of the validation problem.</param>
    /// <param name="type">The type of the validation problem.</param>
    /// <param name="detail">Details about the validation problem.</param>
    /// <param name="instance">The instance of the validation problem.</param>
    /// <returns>A ValidationProblemDetails object representing the validation problem.</returns>
    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 400;

        var errors = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Title = title ?? "One or more validation errors occurred.",
            Type = type,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, errors, statusCode.Value);

        return errors;
    }

    /// <summary>
    /// Applies default values to the ProblemDetails object based on the HTTP context and status code.
    /// </summary>
    /// <param name="httpContext">The HttpContext for the current request.</param>
    /// <param name="problemDetails">The ProblemDetails object to apply defaults to.</param>
    /// <param name="statusCode">The HTTP status code for the problem.</param>
    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        if (httpContext.Items[HttpContextItemKeys.Errors] is List<Error> errors)
        {
            problemDetails.Extensions[HttpContextItemKeys.Errors] = errors;
        }
    }
}
