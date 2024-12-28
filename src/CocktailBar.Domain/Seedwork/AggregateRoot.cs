namespace CocktailBar.Domain.Seedwork;

/// <summary>
/// Primary domain object that acts as the entry point and consistency guardian for a cluster
/// of related entities.
/// </summary>
/// <typeparam name="TId">The identifier type.</typeparam>
public abstract class AggregateRoot<TId> : Aggregate<TId> where TId : notnull
{
    #pragma warning disable SA1600
    protected AggregateRoot() {} // Protected constructor for inheriting classes to use with EF Core
    #pragma warning restore SA1600

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="id">The identifier of the aggregate root.</param>
    protected AggregateRoot(TId id) : base(id) {}
}
