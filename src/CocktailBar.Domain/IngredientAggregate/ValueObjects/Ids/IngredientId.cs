// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Classes;
using CocktailBar.Domain.Common.Base.Interfaces;

namespace CocktailBar.Domain.IngredientAggregate.ValueObjects.Ids;

public sealed class IngredientId : BaseId<IngredientId>, IBaseId<IngredientId>
{
    private IngredientId(Guid value) : base(value) { }

    public static IngredientId New() => new IngredientId(Guid.NewGuid());

    public static IngredientId From(Guid id) => new IngredientId(id);
}
