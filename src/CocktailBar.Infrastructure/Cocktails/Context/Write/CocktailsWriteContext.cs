// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces.Context;

namespace CocktailBar.Infrastructure.Cocktails.Context.Write;

using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Infrastructure.Cocktails.Configuration.Write;
using Microsoft.EntityFrameworkCore;

internal sealed class CocktailsWriteContext(DbContextOptions<CocktailsWriteContext> options)
    : DbContext(options), ICocktailsWriteContext
{
    public DbSet<Cocktail> Cocktails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CocktailsWriteModelConfiguration().Configure(modelBuilder.Entity<Cocktail>());
    }
}
