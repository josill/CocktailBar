// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Context.Write;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Infrastructure.Cocktails.Configuration.Write;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the write-side database context for cocktail-related operations in the CocktailBar application.
/// This context is specifically designed for write operations following CQRS pattern.
/// </summary>
public sealed class CocktailsWriteContext : DbContext, ICocktailsWriteContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CocktailsWriteContext"/> class.
    /// This context handles write operations for the cocktails database.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext for configuration.
    /// These options are typically provided by dependency injection and include the connection string
    /// and any additional database configurations.</param>
    /// <remarks>
    /// This constructor is called by the dependency injection container when the context
    /// is created. The options parameter contains essential configuration including
    /// database provider, connection string, and other DbContext configurations.
    /// </remarks>
    public CocktailsWriteContext(DbContextOptions<CocktailsWriteContext> options)
        : base(options)
    {
    }

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
    /// Configures the model that was discovered by convention from the entity types
    /// exposed in <see cref="DbSet{TEntity}"/> properties on this context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    /// <remarks>
    /// This method applies the configuration for the Cocktail entity using <see cref="CocktailsWriteModelConfiguration"/>.
    /// The configuration includes setting up entity properties, relationships, and any constraints
    /// specific to the write-side of the CQRS pattern.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<Cocktail>());
        new RecipeWriteModelConfiguration().Configure(modelBuilder.Entity<Recipe>());
    }
}
