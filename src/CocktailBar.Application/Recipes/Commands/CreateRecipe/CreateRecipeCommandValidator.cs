// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Enumerations;

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

        RuleFor(x => x.Ingredients)
            .ForEach(i =>
            {
                i.NotNull();
                i.ChildRules(c =>
                {
                    c.RuleFor(x => x.Id).NotEmpty().WithMessage("Ingredient id can't be empty!");
                    c.RuleFor(x => x.Amount.Value).GreaterThan(0).WithMessage("Ingredient amount must be over zero!");
                    c.RuleFor(x => x.Amount.Unit)
                        .Must(unit => Enum.TryParse<WeightUnit>(unit, true, out _))
                        .WithMessage("Ingredient unit is incorrect");
                });
            });
    }
}
