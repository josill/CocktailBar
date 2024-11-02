// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure;

using CocktailBar.Infrastructure.Persistence.Configurations;
using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Read;
using CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Write;
using CocktailBar.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddPersistence(builderConfiguration);

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException(
                                   "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<CocktailsWriteContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ICocktailsWriteContext>(sp =>
            sp.GetRequiredService<CocktailsWriteContext>());

        services.AddDbContext<CocktailsReadContext>(options =>
            options.UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddScoped<ICocktailsReadContext>(sp =>
            sp.GetRequiredService<CocktailsReadContext>());

        // Register UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var databaseSettings = new DatabaseSettings();
        configuration.Bind(DatabaseSettings.SectionName, databaseSettings);

        if (databaseSettings.RecreateOnStartup)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var writeContext = scope.ServiceProvider
                .GetRequiredService<CocktailsWriteContext>();

            writeContext.Database.EnsureDeleted();
            writeContext.Database.EnsureCreated();
        }

        return services;
    }
}
