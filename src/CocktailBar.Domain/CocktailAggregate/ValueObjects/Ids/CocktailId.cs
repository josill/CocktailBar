// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.


using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;

using System;

public record CocktailId(Guid Value) : IId<CocktailId, Guid>
{
    public static CocktailId New() => new(Guid.NewGuid());

    public static CocktailId From(Guid id) => new(id);
}
