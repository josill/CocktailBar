using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Exceptions;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.Ingredients.Queries.FindIngredients;

public class FindIngredientsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<FindIngredientsQuery, ErrorOr<FindIngredientsResult>>
{
    public async Task<ErrorOr<FindIngredientsResult>> Handle(FindIngredientsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var ingredients = await unitOfWork.Ingredients.GetPagedListAsync<IngredientAggregate>(request.Page, request.PageSize);
            var result = FindIngredientsResult.From(ingredients);
            return result;
        }
        catch (Exception e)
        {
            throw SomethingWentWrongException.For<IngredientAggregate>($"Error retrieving ingredients: {e.Message}");
        }
    }
}
