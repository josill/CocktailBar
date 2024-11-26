// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Classes;
using CocktailBar.Domain.Common.Base.Interfaces;

namespace CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

using System;

public sealed class StockItemId : BaseId<StockItemId>, IBaseId<StockItemId>
{
    private StockItemId(Guid value) : base(value) { }

    public static StockItemId New() => new StockItemId(Guid.NewGuid());

    public static StockItemId From(Guid id) => new StockItemId(id);
}
