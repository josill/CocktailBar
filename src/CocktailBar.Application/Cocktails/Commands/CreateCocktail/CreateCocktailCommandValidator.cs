// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using FluentValidation;

public class CreateCocktailCommandValidator : AbstractValidator<CreateCocktailCommand>
{
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
