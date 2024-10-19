namespace CocktailBar.Domain.Base;

public abstract class EntityWithMetadata<TId> : IEntity<TId>, IEquatable<EntityWithMetadata<TId>>
where TId : notnull
{
    public TId Id { get; }
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime? UpdatedAt { get; private set; }
    
    protected EntityWithMetadata(TId id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EntityWithMetadata<TId>)obj);
    }

    public static bool operator ==(EntityWithMetadata<TId> left, EntityWithMetadata<TId> right)
    {
        return Equals(left, right);
    }
    
    public static bool operator !=(EntityWithMetadata<TId> left, EntityWithMetadata<TId> right)
    {
        return !Equals(left, right);
    }

    public bool Equals(EntityWithMetadata<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TId>.Default.Equals(Id, other.Id) && CreatedAt.Equals(other.CreatedAt) && Nullable.Equals(UpdatedAt, other.UpdatedAt);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, CreatedAt, UpdatedAt);
    }
    
    
    protected virtual void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}