// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Recipes.Common;

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using ErrorOr;
using MediatR;

public record CreateRecipeCommand(string Name, string Instructions) : IRequest<ErrorOr<RecipeResult>>;
