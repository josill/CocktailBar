namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Base class for domain entities with generic ID type.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Entity<TId>
{
    #pragma warning disable SA1600
    protected Entity() {} // Protected constructor for inheriting classes to use with EF Core
#pragma warning restore SA1600

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
    /// </summary>
    /// <param name="id">the identifier for the entity.</param>
    protected Entity(TId id) => Id = id;

    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public TId Id { get; } = default!;
}
