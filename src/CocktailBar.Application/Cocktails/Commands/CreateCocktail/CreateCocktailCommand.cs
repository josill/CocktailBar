// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using ErrorOr;
using MediatR;

/// <summary>
/// Command for creating a new cocktail in the system.
/// Implements IRequest pattern for handling through MediatR.
/// </summary>
/// <param name="Name">The name of the cocktail to be created. Must be unique in the system.</param>
/// <param name="Description">A detailed description of the cocktail, including ingredients and preparation method.</param>
/// <param name="RecipeId">The unique identifier for the recipe associated with this cocktail.</param>
/// <remarks>
/// This command is part of the application layer and follows CQRS pattern.
/// It returns ErrorOr type to handle both success and failure cases.
/// </remarks>
public record CreateCocktailCommand(
    string Name,
    string Description,
    Guid RecipeId) : IRequest<ErrorOr<CreateCocktailResult>>;

/// <summary>
/// Represents the result of a successful cocktail creation operation.
/// </summary>
/// <param name="CocktailId">The unique identifier assigned to the newly created cocktail.</param>
/// <param name="Name">The name of the created cocktail.</param>
/// <param name="Description">The description of the created cocktail.</param>
/// <param name="RecipeId">The unique identifier of the associated recipe.</param>
/// <remarks>
/// This result is returned only when the cocktail creation is successful.
/// It contains all essential information about the newly created cocktail.
/// </remarks>
public record CreateCocktailResult(Guid CocktailId, string Name, string Description, Guid RecipeId);
