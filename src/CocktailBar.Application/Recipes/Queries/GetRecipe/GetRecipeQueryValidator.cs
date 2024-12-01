// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using FluentValidation;

namespace CocktailBar.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryValidator : AbstractValidator<GetRecipeQuery>
{
    public GetRecipeQueryValidator()
    {
        RuleFor(x => x.RecipeId)
            .NotEmpty();
    }
}
