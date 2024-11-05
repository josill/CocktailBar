// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Context.Read;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Read;
using CocktailBar.Infrastructure.Cocktails.Configuration.Read;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the read-side database context for cocktail-related operations in the CocktailBar application.
/// This internal context is specifically designed for read operations following the CQRS pattern.
/// </summary>
public sealed class CocktailsReadContext : DbContext, ICocktailsReadContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailsReadContext"/> class.
    /// This constructor creates a read-only context for accessing cocktail and recipe data.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext for configuration,
    /// typically containing read-specific settings such as connection strings and query tracking behavior.</param>
    /// <remarks>
    /// Following CQRS principles, this context is optimized for read operations
    /// and should not be used for data modifications.
    /// </remarks>
    public CocktailsReadContext(DbContextOptions<CocktailsReadContext> options)
        : base(options)
    {
    }

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
        new CocktailsReadModelConfiguration().Configure(modelBuilder.Entity<CocktailReadModel>());
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
