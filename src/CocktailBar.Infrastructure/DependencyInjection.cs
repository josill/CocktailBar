// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure;

using CocktailBar.Infrastructure.Persistence;
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
        services.AddDbContext<RelationalWriteDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddDbContext<RelationalReadDbContext>(
            options => options
                .UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }
}
