// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Recipes.Common;
using MediatR;
using ErrorOr;

namespace CocktailBar.Application.Recipes.Queries.GetRecipe;

public record GetRecipeQuery(Guid RecipeId) : IRequest<ErrorOr<RecipeResult>>;
