namespace CocktailBar.Domain.Exceptions;

/// <summary>
/// Represents an exception that occurs when a requested resource is not found.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    private NotFoundException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of <see cref="NotFoundException"/>.
    /// </summary>
    /// <typeparam name="T">The type associated with this not found exception.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>The thrown not found exception.</returns>
    public static Exception For<T>(string message) => throw new NotFoundException(message);
}
