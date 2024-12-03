// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.IngredientAggregate.ValueObjects.Ids;

public record IngredientId(Guid Value) : IId<IngredientId, Guid>
{
    public static IngredientId New() => new(Guid.NewGuid());

    public static IngredientId From(Guid id) => new(id);
}
