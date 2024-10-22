// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using CocktailBar.Contracts.Cocktails;
using ErrorOr;
using MediatR;

public record CreateCocktailCommand(
    string Name,
    string Description) : IRequest<ErrorOr<CreateCocktailResponse>>;
