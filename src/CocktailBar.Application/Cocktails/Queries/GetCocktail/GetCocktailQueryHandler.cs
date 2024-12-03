// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.Cocktails.Queries.GetCocktail;

public class GetCocktailQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCocktailQuery, ErrorOr<CocktailResult>>
{
    public async Task<ErrorOr<CocktailResult>> Handle(GetCocktailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cocktail = await unitOfWork.Cocktails.GetByIdAsync(CocktailId.From(request.CocktailId));
            DomainException.For<Cocktail>(cocktail == null, "Cocktail with the specified id not found!");

            var result = CocktailResult.From(cocktail!);
            return result;
        }
        catch (Exception e)
        {
            return Errors.Common.SomethingWentWrong(e.Message);
        }
    }
}
