// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

namespace CocktailBar.Infrastructure;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Infrastructure.Cocktails.Context.Read;
using CocktailBar.Infrastructure.Cocktails.Context.Write;
using CocktailBar.Infrastructure.Cocktails.Repository;
using CocktailBar.Infrastructure.Common.Settings;
using CocktailBar.Infrastructure.Common.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for configuring infrastructure services in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
   /// <summary>
   /// Adds infrastructure services to the service collection.
   /// </summary>
   /// <param name="services">The service collection to add services to.</param>
   /// <param name="builderConfiguration">The configuration manager containing application settings.</param>
   /// <returns>The service collection for method chaining.</returns>
   public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       ConfigurationManager builderConfiguration)
   {
       services.AddPersistence(builderConfiguration);

       return services;
   }

   /// <summary>
   /// Configures and adds persistence-related services to the service collection.
   /// Sets up database contexts, unit of work, and handles database initialization.
   /// </summary>
   /// <param name="services">The service collection to add services to.</param>
   /// <param name="configuration">The configuration containing database settings.</param>
   /// <returns>The service collection for method chaining.</returns>
   /// <exception cref="InvalidOperationException">Thrown when the default connection string is not found in configuration.</exception>
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

       services.AddScoped<IUnitOfWork, UnitOfWork>();
       services.AddScoped<IRepository<Cocktail, CocktailId>, CocktailsRepository>();
       services.AddScoped<IRepository<Recipe, RecipeId>, RecipeRepository>();

       var databaseSettings = new DatabaseSettings();
       configuration.Bind(DatabaseSettings.SectionName, databaseSettings);

       if (databaseSettings.RecreateOnStartup)
       {
           using var scope = services.BuildServiceProvider().CreateScope();

           var cocktailsDbContext = scope.ServiceProvider.GetRequiredService<CocktailsWriteContext>();

           cocktailsDbContext.Database.EnsureDeleted();
           cocktailsDbContext.Database.EnsureCreated();
           cocktailsDbContext.Database.Migrate();
       }

       return services;
   }
}
