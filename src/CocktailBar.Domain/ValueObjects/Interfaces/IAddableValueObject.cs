// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.ValueObjects.Interfaces;

/// <summary>
/// Interface for value objects that support addition
/// </summary>
/// <typeparam name="T">The type of the value object</typeparam>
public interface IAddableValueObject<T> where T : ValueObject<T>
{
    T Add(T other);
}
