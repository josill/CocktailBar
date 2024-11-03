// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class CocktailId : BaseId<CocktailId>, IBaseId<CocktailId>
{
    private CocktailId(Guid value) : base(value) { }

    public static CocktailId New() => new CocktailId(Guid.NewGuid());

    public static CocktailId From(Guid id) => new CocktailId(id);
}
