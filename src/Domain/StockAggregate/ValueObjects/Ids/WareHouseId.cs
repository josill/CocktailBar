// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.ValueObjects.Ids;

using System;
using CocktailBar.Domain.Common;

public sealed class WareHouseId : BaseId<WareHouseId>, IBaseId<WareHouseId>
{
    private WareHouseId(Guid value) : base(value) { }

    public static WareHouseId New() => new WareHouseId(Guid.NewGuid());

    public static WareHouseId From(Guid id) => new WareHouseId(id);
}
