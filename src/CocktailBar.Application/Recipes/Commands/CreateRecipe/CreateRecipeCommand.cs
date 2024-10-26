// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using ErrorOr;
using MediatR;

/// <summary>
/// Command to create a new recipe in the system.
/// Implements IRequest for MediatR pattern returning either an error or CreateRecipeResult.
/// </summary>
/// <param name="Name">The name of the recipe to create.</param>
/// <param name="Instructions">Step-by-step instructions for preparing the recipe.</param>
/// <remarks>
/// This command is processed by its corresponding handler to create a new recipe.
/// The handler will perform validation and return appropriate errors if the command is invalid.
/// </remarks>
public record CreateRecipeCommand(string Name, string Instructions) : IRequest<ErrorOr<CreateRecipeResult>>;

/// <summary>
/// Represents the result of a successful recipe creation operation.
/// Contains the essential information about the newly created recipe.
/// </summary>
/// <param name="RecipeId">The unique identifier assigned to the new recipe.</param>
/// <param name="Name">The name of the created recipe.</param>
/// <param name="Instructions">The instructions for preparing the recipe.</param>
/// <remarks>
/// This record is returned when a CreateRecipeCommand is successfully processed.
/// It contains a subset of the recipe's data that's relevant for the creation response.
/// </remarks>
public record CreateRecipeResult(Guid RecipeId, string Name, string Instructions);
