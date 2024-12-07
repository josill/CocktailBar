// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Cocktails.Common;
using CocktailBar.Domain.Common.Errors;

namespace CocktailBar.Application.Cocktails.Commands.CreateCocktail;

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.CocktailAggregate.Entities;
using CocktailBar.Domain.CocktailAggregate.ValueObjects.Ids;
using ErrorOr;
using MediatR;

public class CreateCocktailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCocktailCommand, ErrorOr<CocktailResult>>
{
    public async Task<ErrorOr<CocktailResult>> Handle(CreateCocktailCommand request, CancellationToken cancellationToken)
    {
        var cocktail = Cocktail.Create(request.Name, request.Description, RecipeId.From(request.RecipeId));

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Cocktails.AddAsync(cocktail);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            return Errors.Common.SomethingWentWrong("Error creating the cocktail entity");
        }

        return CocktailResult.From(cocktail);
    }
}
