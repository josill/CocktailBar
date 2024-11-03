// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.OrderAggregate.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class OrderId : BaseId<OrderId>, IBaseId<OrderId>
{
    private OrderId(Guid value) : base(value) { }

    public static OrderId New() => new OrderId(Guid.NewGuid());

    public static OrderId From(Guid id) => new OrderId(id);
}
