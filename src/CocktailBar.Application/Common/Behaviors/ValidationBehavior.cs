// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Behaviors;

using ErrorOr;
using FluentValidation;
using MediatR;

/// <summary>
/// Implements a MediatR pipeline behavior for handling validation using FluentValidation.
/// This behavior runs before the request handler and validates the request if a validator is provided.
/// </summary>
/// <typeparam name="TRequest">The type of request being handled. Must implement IRequest{TResponse}.</typeparam>
/// <typeparam name="TResponse">The type of response being returned. Must implement IErrorOr.</typeparam>
/// <remarks>
/// This behavior is optional in the pipeline - if no validator is provided, the request will pass through unchanged.
/// Validation errors are converted to ErrorOr types for consistent error handling throughout the application.
/// </remarks>
public class ValidationBehavior<TRequest, TResponse>(
    IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    /// <summary>
    /// Handles the validation pipeline step for the request.
    /// </summary>
    /// <param name="request">The request to be validated and processed.</param>
    /// <param name="next">The delegate to the next step in the pipeline.</param>
    /// <param name="cancellationToken">Cancellation token for async operations.</param>
    /// <returns>
    /// If validation passes or no validator exists: The result from the next pipeline step.
    /// If validation fails: A collection of validation errors wrapped in an ErrorOr response.
    /// </returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validator is null) return await next();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid) return await next();

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));

        return (dynamic)errors;
    }
}
