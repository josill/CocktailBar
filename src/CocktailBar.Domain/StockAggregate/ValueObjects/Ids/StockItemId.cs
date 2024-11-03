// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class StockItemId : BaseId<StockItemId>, IBaseId<StockItemId>
{
    private StockItemId(Guid value) : base(value) { }

    public static StockItemId New() => new StockItemId(Guid.NewGuid());

    public static StockItemId From(Guid id) => new StockItemId(id);
}
