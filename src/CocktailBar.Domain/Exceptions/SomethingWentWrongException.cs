namespace CocktailBar.Domain.Exceptions;

/// <summary>
/// Represents an exception that occurs when an unexpected error happens in the system.
/// </summary>
public class SomethingWentWrongException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SomethingWentWrongException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    private SomethingWentWrongException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of <see cref="SomethingWentWrongException"/>.
    /// </summary>
    /// <typeparam name="T">The type associated with this exception.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>The thrown exception.</returns>
    public static Exception For<T>(string message) => throw new SomethingWentWrongException(message);
}
