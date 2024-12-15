// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Domain.Aggregates.Cocktail;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Exceptions;

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using CocktailBar.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

public class CreateCocktailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCocktailCommand, ErrorOr<CocktailResult>>
{
    public async Task<ErrorOr<CocktailResult>> Handle(CreateCocktailCommand request, CancellationToken cancellationToken)
    {
        var cocktail = CocktailAggregate.Create(request.Name, request.Description, new RecipeId(request.RecipeId));

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Cocktails.AddAsync(cocktail);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw SomethingWentWrongException.For<CocktailAggregate>($"Error creating the cocktail entity: {e.Message}");
        }

        return CocktailResult.From(cocktail);
    }
}
