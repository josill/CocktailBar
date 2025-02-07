namespace CocktailBar.Contracts.StockOrders;

public record CreateStockOrderRequest(string OrderNumber, StockOrderPrice Price, DateTime OrderedAtDate, DateTime OrderArriveDate, List<StockItem> StockItems);

public record StockOrderPrice(Price OrderCost, Price ShippingCost);

public record Price(decimal Amount, string Currency);
