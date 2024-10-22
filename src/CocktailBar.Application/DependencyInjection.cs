// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application;

using System.Reflection;
using CocktailBar.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides dependency injection extension methods for setting up application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application-specific services to the dependency injection container.
    /// </summary>
    /// <remarks>
    /// This method registers:
    /// - MediatR for CQRS pattern implementation.
    /// - Validation behaviors for request validation.
    /// - FluentValidation validators from the current assembly.
    /// </remarks>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The same service collection for method chaining.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(DependencyInjection)
                    .Assembly);
            })
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
