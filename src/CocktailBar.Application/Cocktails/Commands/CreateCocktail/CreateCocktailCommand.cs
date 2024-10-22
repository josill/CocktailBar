// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using CocktailBar.Contracts.Cocktails;
using ErrorOr;
using MediatR;

/// <summary>
/// Command for creating a new cocktail in the system.
/// Implements IRequest pattern for handling through MediatR.
/// </summary>
/// <remarks>
/// This command is part of the application layer and follows CQRS pattern.
/// It returns ErrorOr type to handle both success and failure cases.
/// </remarks>
/// <param name="Name">The name of the cocktail to be created. Must be unique in the system.</param>
/// <param name="Description">A detailed description of the cocktail, including ingredients and preparation method.</param>
public record CreateCocktailCommand(
    string Name,
    string Description) : IRequest<ErrorOr<CreateCocktailResponse>>;
