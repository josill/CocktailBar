using CocktailBar.Application.Common.Results;
using FluentValidation;

namespace CocktailBar.Application.Common.Validators;

public class PagedQueryValidator<T> : AbstractValidator<PagedResult<T>> where T : class
{
    public PagedQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page has to be bigger than zero.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size has to be bigger than zero");
    }
}
