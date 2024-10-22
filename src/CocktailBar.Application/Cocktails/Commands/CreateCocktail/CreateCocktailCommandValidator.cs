// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using FluentValidation;

/// <summary>
/// Validator for the CreateCocktailCommand.
/// </summary>
public class CreateCocktailCommandValidator : AbstractValidator<CreateCocktailCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCocktailCommandValidator"/> class.
    /// </summary>
    public CreateCocktailCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.RecipeId)
            .NotEmpty();
    }
}
