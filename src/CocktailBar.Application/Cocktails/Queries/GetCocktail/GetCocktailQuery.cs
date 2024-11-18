// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.Cocktails.Queries.GetCocktail;

public record GetCocktailQuery(Guid CocktailId) : IRequest<ErrorOr<CocktailResult>>;
