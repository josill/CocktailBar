// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Classes;
using CocktailBar.Domain.Common.Base.Interfaces;

namespace CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;

public sealed class RecipeId : BaseId<RecipeId>, IBaseId<RecipeId>
{
    private RecipeId(Guid value) : base(value) { }

    public static RecipeId New() => new RecipeId(Guid.NewGuid());

    public static RecipeId From(Guid id) => new RecipeId(id);
}
