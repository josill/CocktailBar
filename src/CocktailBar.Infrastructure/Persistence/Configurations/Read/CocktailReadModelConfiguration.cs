// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations.Read;

using CocktailBar.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the database schema and mapping for the CocktailReadModel entity.
/// This configuration is specifically for the read-side of the CQRS pattern.
/// </summary>
internal sealed class CocktailReadModelConfiguration : IEntityTypeConfiguration<CocktailReadModel>
{
    /// <summary>
    /// Configures the entity mapping for CocktailReadModel.
    /// Defines the primary key and any other database schema specifications.
    /// </summary>
    /// <param name="builder">The entity type builder used to configure the CocktailReadModel.</param>
    public void Configure(EntityTypeBuilder<CocktailReadModel> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
