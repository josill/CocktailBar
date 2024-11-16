// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Common.Errors;

/// <summary>
/// Represents a infrastructure-specific exception that is associated with a particular type.
/// </summary>
public class InfrastructureException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfrastructureException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    internal InfrastructureException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of <see cref="InfrastructureException"/> if the condition is true.
    /// </summary>
    /// <typeparam name="T">The type associated with this domain exception.</typeparam>
    /// <param name="condition">The condition to check.</param>
    /// <param name="message">The error message.</param>
    public static void For<T>(bool condition, string message)
    {
        if (condition) throw new InfrastructureException<T>(message);
    }
}

/// <summary>
/// Represents a strongly-typed domain exception for a specific type.
/// </summary>
/// <typeparam name="T">The type associated with this infrastructure exception.</typeparam>
public sealed class InfrastructureException<T> : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfrastructureException{T}"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    internal InfrastructureException(string message) : base(message) { }
}
