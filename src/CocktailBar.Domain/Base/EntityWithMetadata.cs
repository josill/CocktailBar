namespace CocktailBar.Domain.Base;

public abstract class EntityWithMetadata<TId> : IEntity<TId>
{
    public TId Id { get; }
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime? UpdatedAt { get; private set; }
    
    protected EntityWithMetadata(TId id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        Id = id;
    }
    
    protected virtual void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}