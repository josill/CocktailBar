// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Cocktail;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface ICocktailsReadContext : IDisposable
{
    DbSet<CocktailReadModel> Cocktails { get; }
}
