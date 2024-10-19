using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Order;

public class Order: EntityWithMetadata<OrderId>
{
    // public OrderNumber OrderNumber { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }
    
    public Order(OrderId id) : base(id)
    {
    }
}

public readonly record struct OrderId(Guid Value);