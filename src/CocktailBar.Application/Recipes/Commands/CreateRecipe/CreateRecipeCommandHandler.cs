// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.Recipes.Common;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.Exceptions;
using Amount = CocktailBar.Domain.ValueObjects.Amount;

namespace CocktailBar.Application.Recipes.Commands.CreateRecipe;

using ErrorOr;
using MediatR;

public class CreateRecipeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, ErrorOr<RecipeResult>>
{
    public async Task<ErrorOr<RecipeResult>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = RecipeAggregate.Create(request.Name, request.Instructions);
        foreach (var ing in request.Ingredients)
        {
            var amount = Amount.Create(ing.Amount.Value, Enum.Parse<WeightUnit>(ing.Amount.Unit));
            recipe.AddIngredient(new IngredientId(ing.Id), amount);
        }

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Recipes.AddAsync(recipe);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw SomethingWentWrongException.For<RecipeAggregate>($"Error creating the recipe entity: {e.Message}");
        }

        return RecipeResult.From(recipe);
    }
}
