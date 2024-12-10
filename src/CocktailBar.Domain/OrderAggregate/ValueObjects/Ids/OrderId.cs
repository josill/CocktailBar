// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.


using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.OrderAggregate.ValueObjects.Ids;

using System;

public record OrderId(Guid Value) : Id<Guid>(Value);

