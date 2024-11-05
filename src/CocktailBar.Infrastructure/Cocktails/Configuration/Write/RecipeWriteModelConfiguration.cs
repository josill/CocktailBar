// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the Entity Framework Core mapping for the Recipe domain entity.
/// This configuration is used specifically for write operations in a CQRS pattern.
/// </summary>
/// <remarks>
/// This class defines the database schema and relationships for the Recipe entity,
/// handling the write-side persistence in the CQRS architecture. It maps the domain model
/// directly to the database structure for write operations.
/// </remarks>
internal sealed class RecipeWriteModelConfiguration : IEntityTypeConfiguration<Recipe>
{
    /// <summary>
    /// Configures the entity mapping for the Recipe domain entity.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the Recipe entity.</param>
    /// <remarks>
    /// Currently configures:
    /// - Primary key using the Id property
    ///
    /// This configuration supports write operations on the Recipe aggregate root
    /// within the cocktail domain context.
    /// </remarks>
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ComplexProperty(r => r.Ingredients);
    }
}
