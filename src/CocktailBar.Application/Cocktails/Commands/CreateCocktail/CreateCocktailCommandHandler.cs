// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Domain.RecipeAggregate.ValueObjects.Ids;
using CocktailBar.Domain.Seedwork.Errors;

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using ErrorOr;
using MediatR;

public class CreateCocktailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCocktailCommand, ErrorOr<CocktailResult>>
{
    public async Task<ErrorOr<CocktailResult>> Handle(CreateCocktailCommand request, CancellationToken cancellationToken)
    {
        var cocktail = Cocktail.Create(request.Name, request.Description, new RecipeId(request.RecipeId));

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Cocktails.AddAsync(cocktail);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw SomethingWentWrongException.For<Cocktail>($"Error creating the cocktail entity: {e.Message}");
        }

        return CocktailResult.From(cocktail);
    }
}
