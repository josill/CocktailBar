// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork;

namespace CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;

public record RecipeId(Guid Value) : Id<Guid>(Value);

