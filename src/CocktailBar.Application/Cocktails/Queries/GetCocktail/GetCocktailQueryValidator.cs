// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using FluentValidation;

namespace CocktailBar.Application.Cocktails.Queries.GetCocktail;

public class GetCocktailQueryValidator : AbstractValidator<GetCocktailQuery>
{
    public GetCocktailQueryValidator()
    {
        RuleFor(x => x.CocktailId)
            .NotEmpty();
    }
}
