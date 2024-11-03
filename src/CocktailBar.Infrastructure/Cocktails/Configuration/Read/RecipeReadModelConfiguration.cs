// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Cocktails.Configuration.Read;

using CocktailBar.Infrastructure.Recipes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the Entity Framework Core mapping for the RecipeReadModel entity.
/// This configuration is used specifically for read operations in a CQRS pattern.
/// </summary>
/// <remarks>
/// This class defines the database schema and relationships for the Recipe read model,
/// separate from the write model configuration to support the CQRS pattern.
/// </remarks>
internal sealed class RecipeReadModelConfiguration : IEntityTypeConfiguration<RecipeReadModel>
{
    /// <summary>
    /// Configures the entity mapping for RecipeReadModel.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the RecipeReadModel.</param>
    /// <remarks>
    /// Currently configures:
    /// - Primary key using the Id property
    /// Additional configurations can be added here as needed.
    /// </remarks>
    public void Configure(EntityTypeBuilder<RecipeReadModel> builder)
    {
        builder.HasKey(r => r.Id);
    }
}
