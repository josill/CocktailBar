// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using ErrorOr;
using MediatR;

public record CreateCocktailCommand(
    string Name,
    string Description,
    Guid RecipeId) : IRequest<ErrorOr<CocktailResult>>;
