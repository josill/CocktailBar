// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.


using CocktailBar.Domain.CocktailAggregate.Entities;

namespace CocktailBar.Application.Recipes.Common;

public record RecipeResult(Guid RecipeId, string Name, string Instructions)
{
    public static RecipeResult From(Recipe recipe)
    {
        return new RecipeResult(
            recipe.Id.Value,
            recipe.Name,
            recipe.Instructions);
    }
}
