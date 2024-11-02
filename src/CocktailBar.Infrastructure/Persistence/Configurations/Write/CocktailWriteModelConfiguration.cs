// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the database schema and mapping for the Cocktail domain entity.
/// This configuration is specifically for the write-side of the CQRS pattern.
/// </summary>
internal sealed class CocktailWriteModelConfiguration : IEntityTypeConfiguration<Cocktail>
{
    /// <summary>
    /// Configures the entity mapping for Cocktail domain entity.
    /// Defines the primary key and relationships with other entities.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the Cocktail entity.</param>
    /// <remarks>
    /// Current implementation:
    /// - Configures the Id property as the primary key
    /// - Pending: Configuration of relationship with Recipe entity.
    /// </remarks>
    public void Configure(EntityTypeBuilder<Cocktail> builder)
    {
        builder.HasKey(c => c.Id);

        // TODO: Configure relation to recipe id
    }
}
