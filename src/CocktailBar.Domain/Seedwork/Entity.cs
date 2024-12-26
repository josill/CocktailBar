namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for domain entities. Entities must belong to an aggregate root and cannot be modified directly.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; } = default!;
}
