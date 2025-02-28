// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Exceptions;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.Cocktails.Queries.GetCocktail;

public class GetCocktailQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCocktailQuery, ErrorOr<CocktailResult>>
{
    public async Task<ErrorOr<CocktailResult>> Handle(GetCocktailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cocktail = await unitOfWork.Cocktails.GetByIdAsync<CocktailAggregate>(new CocktailId(request.CocktailId));
            if (cocktail is null) throw NotFoundException.For<CocktailAggregate>($"Cocktail with the specified id: {request.CocktailId} not found!");

            var result = CocktailResult.From(cocktail);
            return result;
        }
        catch (Exception e)
        {
            throw SomethingWentWrongException.For<CocktailAggregate>($"Error retrieving the cocktail: {e.Message}");
        }
    }
}
