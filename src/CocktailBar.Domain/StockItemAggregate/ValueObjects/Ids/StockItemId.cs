// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.StockItemAggregate.ValueObjects.Ids;

public record StockItemId(Guid Value) : IId<StockItemId, Guid>
{
    public static StockItemId New() => new(Guid.NewGuid());

    public static StockItemId From(Guid id) => new(id);
}
