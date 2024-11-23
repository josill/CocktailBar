// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.StockAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class WarehouseId : BaseId<WarehouseId>, IBaseId<WarehouseId>
{
    private WarehouseId(Guid value) : base(value) { }

    public static WarehouseId New() => new WarehouseId(Guid.NewGuid());

    public static WarehouseId From(Guid id) => new WarehouseId(id);
}