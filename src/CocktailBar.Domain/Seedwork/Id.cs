// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Seedwork.Errors;

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for all strongly typed identifier.
/// </summary>
/// <typeparam name="T">Primitive type of the identifier.</typeparam>
public abstract record Id<T>
{
    /// <summary>
    /// Gets the validated value of the identifier.
    /// </summary>
    public T Value { get; } = default!;
    
    protected Id() {}

    /// <summary>
    /// Initializes a new instance of the ValidatedId with validation.
    /// </summary>
    /// <param name="value">The value to validate and store.</param>
    protected Id(T value)
    {
        Validate(value);
        Value = value;
    }

    /// <summary>
    /// Validates the provided primitive identifier based on its type.
    /// </summary>
    /// <param name="value">The primitive identifier to validate.</param>
    /// <exception cref="DomainException">Thrown when validation fails.</exception>
    private static void Validate(T value)
    {
        if (value is Guid guid && guid == Guid.Empty) 
            throw DomainException.For<Id<Guid>>("GUID value cannot be empty.");
        if (value is string str && string.IsNullOrWhiteSpace(str))
            throw DomainException.For<Id<string>>("String value cannot be empty.");
        if (value is int and > 0)
            throw DomainException.For<Id<int>>("Integer value must be positive or bigger than zero.");
    }
}

