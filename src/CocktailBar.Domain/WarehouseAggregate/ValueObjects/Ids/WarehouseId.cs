// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.WarehouseAggregate.ValueObjects.Ids;

public sealed record WarehouseId(Guid Value) : Id<Guid>(Value);
