using CocktailBar.Domain.OrderAggregate.ValueObjects;

namespace CocktailBar.Domain.OrderAggregate.Entities;

using CocktailBar.Domain.Base;
using CocktailBar.Domain.OrderAggregate.ValueObjects.Ids;

/// <summary>
/// Represents an order in the cocktail bar domain.
/// This class inherits from EntityWithMetadata and uses OrderId as its identifier.
/// </summary>
public class Order : EntityWithMetadata<OrderId>
{
    /// <summary>
    /// Private collection of order items.
    /// This backing field allows for encapsulation of the order items list.
    /// </summary>
    private readonly List<OrderItem> _orderItems = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Order"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the order.</param>
    public Order(OrderId id) : base(id)
    {
    }

    /// <summary>
    /// Gets a read-only list of order items.
    /// This property provides controlled access to the order items, preventing external modification.
    /// </summary>
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.ToList().AsReadOnly();

    /// <summary>
    /// Adds an item to the order.
    /// </summary>
    /// <param name="item">The order item to add.</param>
    /// <exception cref="ArgumentNullException">Thrown if the provided item is null.</exception>
    public void AddItem(OrderItem item)
    {
        // TODO: Add validation logic
        _orderItems.Add(item);
    }

    /// <summary>
    /// Removes an item from the order.
    /// </summary>
    /// <param name="item">The order item to remove.</param>
    /// <returns>True if the item was successfully removed; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided item is null.</exception>
    public bool RemoveItem(OrderItem item)
    {
        // TODO: Add validation logic
        return _orderItems.Remove(item);
    }
}