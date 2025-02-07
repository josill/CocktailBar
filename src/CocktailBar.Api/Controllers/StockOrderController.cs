using CocktailBar.Api.Controllers.Common;
using CocktailBar.Application.StockOrders.Commands.CreateStockOrder;
using CocktailBar.Contracts.StockOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CocktailBar.Api.Controllers;

[Route("stock-orders")]
public class StockOrderController(ISender mediatr) : ApiController
{
    /// <summary>
    /// Creates a new stock order.
    /// </summary>
    /// <param name="request">The request containing stock order details.</param>
    /// <returns>Returns the created stock order's id.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateStockOrderRequest request)
    {
        var command = new CreateStockOrderCommand(request.OrderNumber, request.Price, request.OrderedAtDate, request.OrderArriveDate, request.StockItems);
        var result = await mediatr.Send(command);

        return result.Match(Ok, HandleErrors);
    }
}
