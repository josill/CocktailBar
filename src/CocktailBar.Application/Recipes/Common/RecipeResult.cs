// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Aggregates.Recipe;

namespace CocktailBar.Application.Recipes.Common;

public record RecipeResult(Guid RecipeId, string Name, string Instructions)
{
    public static RecipeResult From(RecipeAggregate recipeAggregate)
    {
        return new RecipeResult(
            recipeAggregate.Id.Value,
            recipeAggregate.Name,
            recipeAggregate.Instructions);
    }
}
