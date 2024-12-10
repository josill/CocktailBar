// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.IngredientAggregate.ValueObjects.Ids;

public record IngredientId(Guid Value) : Id<Guid>(Value);

