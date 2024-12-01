// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Contracts.Cocktails;

/// <summary>
/// Represents a request to retrieve a specific cocktail.
/// </summary>
/// <param name="CocktailId">The unique identifier of the cocktail to retrieve.</param>
public record GetCocktailRequest(
    Guid CocktailId);
