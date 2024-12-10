// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork.ValueObjects;

namespace CocktailBar.Domain.Seedwork.Interfaces;

/// <summary>
/// Interface for value objects that support subtraction
/// </summary>
/// <typeparam name="T">The type of the value object</typeparam>
public interface ISubtractableValueObject<T> where T : ValueObject<T>
{
    T Subtract(T other);
}