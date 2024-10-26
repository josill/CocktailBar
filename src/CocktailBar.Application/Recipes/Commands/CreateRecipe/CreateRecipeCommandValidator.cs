// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using FluentValidation;

/// <summary>
/// Validator for the CreateRecipeCommand using FluentValidation.
/// </summary>
public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRecipeCommandValidator"/> class.
    /// Configures validation rules for recipe creation.
    /// </summary>
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Instructions)
            .NotEmpty();
    }
}
