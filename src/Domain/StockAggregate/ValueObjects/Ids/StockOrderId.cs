// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class StockOrderId : BaseId<StockOrderId>, IBaseId<StockOrderId>
{
    private StockOrderId(Guid value) : base(value) { }

    public static StockOrderId New() => new StockOrderId(Guid.NewGuid());

    public static StockOrderId From(Guid id) => new StockOrderId(id);
}
