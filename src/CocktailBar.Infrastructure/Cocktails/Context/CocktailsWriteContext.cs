// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Infrastructure.Cocktails.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.Cocktails.Context;

internal sealed class CocktailsWriteContext(DbContextOptions<CocktailsWriteContext> options)
    : DbContext(options), ICocktailsWriteContext
{
    public DbSet<Cocktail> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new CocktailsWriteModelConfiguration().Configure(builder.Entity<Cocktail>());
    }
}
