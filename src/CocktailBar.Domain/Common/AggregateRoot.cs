namespace CocktailBar.Domain.Base;

public abstract class AggregateRoot<TId>(TId id) : EntityWithMetadata<TId>(id)
    where TId : notnull;