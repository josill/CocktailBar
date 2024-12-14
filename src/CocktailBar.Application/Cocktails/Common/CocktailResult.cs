// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Cocktail;

namespace CocktailBar.Application.Cocktails.Common;

public record CocktailResult(Guid CocktailId, string Name, string Description, Guid RecipeId)
{
    public static CocktailResult From(CocktailAggregate cocktailAggregate)
    {
        return new CocktailResult(
            cocktailAggregate.Id.Value,
            cocktailAggregate.Name,
            cocktailAggregate.Description,
            cocktailAggregate.RecipeId.Value);
    }
};
