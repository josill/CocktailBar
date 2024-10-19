using CocktailBar.Domain.Base;

namespace CocktailBar.Domain.Cocktail.ValueObjects.Ids;

public class RecipeId(Guid value) : ValueObject<RecipeId>
{
    private Guid Value { get; } = value;

    public static RecipeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        throw new NotImplementedException();
    }
}