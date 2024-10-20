// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.CocktailAggregate;

using System;

/// <summary>
/// Exception thrown when a cocktail name is empty.
/// </summary>
public class CocktailNameCanNotBeEmpty() : Exception("Cocktail name can not be empty.");

/// <summary>
/// Exception thrown when a cocktail description is empty.
/// </summary>
public class CocktailDescriptionCanNotBeEmpty() : Exception("Cocktail cannot be a negative value.");

/// <summary>
/// Exception thrown when a weight value has more than two decimal places.
/// </summary>
public class MoreThanThreeDecimalPlacesInWeightValueException() : Exception("Weight value cannot have more than three decimal places.");

/// <summary>
/// Exception thrown when a weight value is negative.
/// </summary>
public class WeightCannotBeNegativeException() : Exception("Weight cannot be a negative value.");

/// <summary>
/// Exception thrown when recipe instructions are empty.
/// </summary>
public class RecipeInstructionsCannotBeEmpty() : Exception("Recipe instructions cannot be empty.");

/// <summary>
/// Exception thrown when an ingredient already exists in the recipe.
/// </summary>
public class IngredientAlreadyExistsInTheRecipe() : Exception("Ingredient is already used in the recipe.");

/// <summary>
/// Exception thrown when an ingredient does not exist in the recipe.
/// </summary>
public class IngredientDoesntExistInTheRecipe() : Exception("Ingredient not found in the recipe.");
