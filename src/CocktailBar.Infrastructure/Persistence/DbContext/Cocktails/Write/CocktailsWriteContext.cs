// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.DbContext.Cocktails.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the write-side database context for cocktail-related operations in the CocktailBar application.
/// This context is specifically designed for write operations following CQRS pattern.
/// </summary>
public class CocktailsWriteContext : DbContext, ICocktailsWriteContext
{
    /// <summary>
    /// Gets or sets the DbSet for Recipe entities.
    /// This property provides access to recipe data in the database.
    /// </summary>
    public DbSet<Recipe> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for Cocktail entities.
    /// This property provides access to cocktail data in the database.
    /// </summary>
    public DbSet<Cocktail> Cocktails { get; set; }

    /// <summary>
    /// Configures the database model during context initialization.
    /// Applies entity configurations from the assembly using a filter to include only write-side configurations.
    /// </summary>
    /// <param name="modelBuilder">The model builder instance used to construct the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CocktailsWriteContext).Assembly,
            WriteConfigurationFilter);
    }

    /// <summary>
    /// Filters entity configurations to include only those specific to write operations.
    /// </summary>
    /// <param name="type">The type to be evaluated.</param>
    /// <returns>True if the type is a write configuration, false otherwise.</returns>
    private static bool WriteConfigurationFilter(Type type) =>
        type.FullName?.Contains("Configurations.Write") ?? false;
}
