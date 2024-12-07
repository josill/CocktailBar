// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class IngredientId : BaseId<IngredientId>, IBaseId<IngredientId>
{
    private IngredientId(Guid value) : base(value) { }

    public static IngredientId New() => new IngredientId(Guid.NewGuid());

    public static IngredientId From(Guid id) => new IngredientId(id);
}
