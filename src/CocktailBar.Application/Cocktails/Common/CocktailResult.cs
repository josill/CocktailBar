// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.CocktailAggregate.Entities;

namespace CocktailBar.Application.Cocktails.Common;

public record CocktailResult(Guid CocktailId, string Name, string Description, Guid RecipeId)
{
    public static CocktailResult From(Cocktail cocktail)
    {
        return new CocktailResult(
            cocktail.Id.Value,
            cocktail.Name,
            cocktail.Description,
            cocktail.RecipeId.Value);
    }
};