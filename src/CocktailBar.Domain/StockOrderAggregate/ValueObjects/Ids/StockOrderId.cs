// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.StockOrderAggregate.ValueObjects.Ids;

public record StockOrderId(Guid Value) : Id<Guid>(Value);

