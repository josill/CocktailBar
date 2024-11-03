// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class RecipeId : BaseId<RecipeId>, IBaseId<RecipeId>
{
    private RecipeId(Guid value) : base(value) { }

    public static RecipeId New() => new RecipeId(Guid.NewGuid());

    public static RecipeId From(Guid id) => new RecipeId(id);
}
