using Ardalis.GuardClauses;
using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail;

public class Cocktail: ValueObject<Cocktail>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    // TODO: strength, category etc...
    public RecipeId RecipeId { get; private set; }
    // public Recipe Recipe { get; private set; }

    public Cocktail(string name, string description, RecipeId recipeId)
    {
        Validate(name, description);
        Name = name;
        Description = description;
        RecipeId = recipeId; 
    }

    private void Validate(string name, string description)
    {
        Guard.Against.Requires<CocktailNameCanNotBeEmpty>(string.IsNullOrWhiteSpace(name));
        Guard.Against.Requires<CocktailDescriptionCanNotBeEmpty>(string.IsNullOrWhiteSpace(description));
    }
    
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Exception thrown when a cocktail name is empty
/// </summary>
public class CocktailNameCanNotBeEmpty() : Exception("Cocktail name can not be empty!");

/// <summary>
/// Exception thrown when a cocktail description is empty
/// </summary>
public class CocktailDescriptionCanNotBeEmpty() : Exception("Weight cannot be a negative value.");