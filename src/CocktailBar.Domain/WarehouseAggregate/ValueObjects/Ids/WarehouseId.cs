// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.WarehouseAggregate.ValueObjects.Ids;

public record WarehouseId(Guid Value) : IId<WarehouseId, Guid>
{
    public static WarehouseId New() => new(Guid.NewGuid());

    public static WarehouseId From(Guid id) => new(id);
}
