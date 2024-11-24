// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

using CocktailBar.Domain.CocktailAggregate.Entities;
using Microsoft.EntityFrameworkCore;

public interface ICocktailsWriteContext : IDisposable
{
    DbSet<Recipe> Recipes { get; set; }

    DbSet<Cocktail> Cocktails { get; set; }
}
