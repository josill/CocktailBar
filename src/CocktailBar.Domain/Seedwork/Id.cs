// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Exceptions;

namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for all strongly typed identifier.
/// </summary>
/// <typeparam name="T">Primitive type of the identifier.</typeparam>
public record class Id<T>
{
    /// <summary>
    /// Gets the validated value of the identifier.
    /// </summary>
    public T Value { get; }
    
    /// <summary>
    /// Initializes a new instance of the ValidatedId with validation.
    /// </summary>
    /// <param name="value">The value to validate and store.</param>
    public Id(T value)
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
        switch (value)
        {
            case Guid guid when guid == Guid.Empty:
                throw DomainException.For<Id<Guid>>("GUID value cannot be empty.");
            
            case string str when string.IsNullOrWhiteSpace(str):
                throw DomainException.For<Id<string>>("String value cannot be empty.");
            
            case int and <= 0:
                throw DomainException.For<Id<int>>("Integer value must be positive and bigger than zero.");
            
            case Guid:
            case string:
            case int:
                return;
                
            default:
                throw new NotImplementedException($"Validation for type: {typeof(T)} is not implemented.");
        }
    }
}

