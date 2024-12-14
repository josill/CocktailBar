// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Aggregates.Order;

/// <summary>
/// Represents an abstract order item in the cocktail bar system.
/// </summary>
/// <remarks>
/// This class serves as a base for specific types of order items, such as cocktails,
/// ingredients, or other components associated with an order.
/// Future implementations will define the specifics of the order items.
/// </remarks>
public abstract record OrderItem;

// TODO: return to this when cocktail is made
