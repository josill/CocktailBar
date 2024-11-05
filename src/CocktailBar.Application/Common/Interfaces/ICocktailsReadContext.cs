// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

using CocktailBar.Domain.CocktailAggregate.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
/// Defines a contract for read-only database operations in the CocktailBar application.
/// This interface represents the read side of the CQRS pattern, focusing on query operations.
/// </summary>
public interface ICocktailsReadContext : IDisposable
{
    /// <summary>
    /// Gets or sets the queryable set of recipe read models.
    /// Provides read-only access to recipe data in the database.
    /// </summary>
    DbSet<RecipeReadModel> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the queryable set of cocktail read models.
    /// Provides read-only access to cocktail data in the database.
    /// </summary>
    DbSet<CocktailReadModel> Cocktails { get; set; }

    /// <summary>
    /// Gets the database facade, providing access to database-level operations.
    /// Used for managing database connections and transactions in read operations.
    /// </summary>
    DatabaseFacade Database { get; }
}
