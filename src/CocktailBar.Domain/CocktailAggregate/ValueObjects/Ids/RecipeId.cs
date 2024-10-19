using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects.Ids;

public sealed class RecipeId : ValueObject<RecipeId>
{
    private Guid Value { get; }

    private RecipeId(Guid value)
    {
        Value = value;
    }
    
    public static RecipeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }
}