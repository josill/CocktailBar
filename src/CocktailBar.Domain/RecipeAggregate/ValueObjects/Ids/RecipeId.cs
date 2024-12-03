// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;

public record RecipeId(Guid Value) : IId<RecipeId, Guid>
{
    public static RecipeId New() => new(Guid.NewGuid());

    public static RecipeId From(Guid id) => new(id);
}
