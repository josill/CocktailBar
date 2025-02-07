using CocktailBar.Application.StockOrders.Common;
using CocktailBar.Contracts.StockOrders;
using ErrorOr;
using MediatR;

namespace CocktailBar.Application.StockOrders.Commands.CreateStockOrder;

public record CreateStockOrderCommand(
    string OrderNumber,
    StockOrderPrice Price,
    DateTime OrderedAtDate,
    DateTime OrderArriveDate,
    List<StockItem> StockItems) : IRequest<ErrorOr<StockOrderResult>>;
