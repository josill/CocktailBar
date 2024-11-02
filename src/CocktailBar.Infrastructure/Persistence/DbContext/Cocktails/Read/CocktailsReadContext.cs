// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Read;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the read-side database context for cocktail-related operations in the CocktailBar application.
/// This internal context is specifically designed for read operations following the CQRS pattern.
/// </summary>
internal sealed class CocktailsReadContext : DbContext, ICocktailsReadContext
{
    /// <summary>
    /// Gets or sets the DbSet for recipe read models.
    /// This property provides read-only access to recipe data in the database.
    /// </summary>
    public DbSet<RecipeReadModel> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for cocktail read models.
    /// This property provides read-only access to cocktail data in the database.
    /// </summary>
    public DbSet<CocktailReadModel> Cocktails { get; set; }

    /// <summary>
    /// Configures the database model during context initialization.
    /// Applies entity configurations from the assembly using a filter to include only read-side configurations.
    /// </summary>
    /// <param name="modelBuilder">The model builder instance used to construct the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CocktailsReadContext).Assembly,
            WriteConfigurationFilter);
    }

    /// <summary>
    /// Filters entity configurations to include only those specific to read operations.
    /// Only includes types whose full name contains "Configurations.Read".
    /// </summary>
    /// <param name="type">The type to be evaluated.</param>
    /// <returns>True if the type is a read configuration, false otherwise.</returns>
    private static bool WriteConfigurationFilter(Type type) =>
        type.FullName?.Contains("Configurations.Read") ?? false;
}
