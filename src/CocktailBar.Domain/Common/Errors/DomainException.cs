// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common.Errors;

/// <summary>
/// Represents a domain-specific exception that is associated with a particular type.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    internal DomainException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of <see cref="DomainException"/> if the condition is true.
    /// </summary>
    /// <typeparam name="T">The type associated with this domain exception.</typeparam>
    /// <param name="condition">The condition to check.</param>
    /// <param name="message">The error message.</param>
    public static void For<T>(bool condition, string message)
    {
        if (condition) throw new DomainException<T>(message);
    }
}

/// <summary>
/// Represents a strongly-typed domain exception for a specific type.
/// </summary>
/// <typeparam name="T">The type associated with this domain exception.</typeparam>
public sealed class DomainException<T> : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException{T}"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    internal DomainException(string message) : base(message) { }
}
