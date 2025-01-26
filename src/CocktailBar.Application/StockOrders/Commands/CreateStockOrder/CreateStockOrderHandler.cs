using CocktailBar.Application.Common.Interfaces;
using CocktailBar.Application.StockOrders.Common;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Aggregates.Stock;
using CocktailBar.Domain.Aggregates.Warehouse;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.Exceptions;
using CocktailBar.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.StockOrders.Commands.CreateStockOrder;

public class CreateStockOrderHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateStockOrderCommand, ErrorOr<StockOrderResult>>
{
    public async Task<ErrorOr<StockOrderResult>> Handle(CreateStockOrderCommand request, CancellationToken cancellationToken)
    {
        var price = StockOrderPrice.Create(Price.Create(1, Currency.AED), Price.Create(1, Currency.AED));
        var stockOrder = StockOrderAggregate.Create(request.OrderNumber, price, request.OrderedAtDate, request.OrderArriveDate);

        foreach (var item in request.StockItems)
        {
            stockOrder.AddStockItem(new IngredientId(item.IngredientId), new WarehouseId(item.WarehouseId));
        }

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.StockOrders.AddAsync(stockOrder);
            await unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw SomethingWentWrongException.For<RecipeAggregate>($"Error creating the stock order entity: {e.Message}");
        }

        return new StockOrderResult(stockOrder.Id.Value);
    }
}
