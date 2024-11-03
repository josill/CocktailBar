// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Common.Interfaces;

using CocktailBar.Domain.CocktailAggregate.Entities;

/// <summary>
/// Repository interface for managing cocktail entities in the system.
/// </summary>
/// <remarks>
/// This interface extends the generic IRepository interface specifically for Cocktail entities,
/// providing standard CRUD operations and any cocktail-specific data access methods.
/// </remarks>
public interface ICocktailsRepository : IRepository<Cocktail>
{
}
