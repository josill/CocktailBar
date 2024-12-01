// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Classes;
using CocktailBar.Domain.Common.Base.Interfaces;

namespace CocktailBar.Domain.WarehouseAggregate.ValueObjects.Ids;

public sealed class WarehouseId : BaseId<WarehouseId>, IBaseId<WarehouseId>
{
    private WarehouseId(Guid value) : base(value) { }

    public static WarehouseId New() => new WarehouseId(Guid.NewGuid());

    public static WarehouseId From(Guid id) => new WarehouseId(id);
}
