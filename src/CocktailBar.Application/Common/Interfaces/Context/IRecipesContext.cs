// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Application.Common.Interfaces.Context;

public interface IRecipesContext : IDisposable
{
    DbSet<RecipeAggregate> Recipes { get; }
}
