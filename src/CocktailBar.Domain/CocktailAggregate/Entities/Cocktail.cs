using Ardalis.GuardClauses;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;
using CocktailBar.Domain.Common;

namespace CocktailBar.Domain.Cocktail.Entities;

public class Cocktail : AggregateRoot<CocktailId>
{
    public string Name { get; }
    public string Description { get; }
    public RecipeId RecipeId { get; }

    private Cocktail(string name, string description, RecipeId recipeId) : base(CocktailId.CreateUnique())
    {
        Validate(name, description);
        Name = name;
        Description = description;
        RecipeId = recipeId; 
    }
    
    public static Cocktail Create(
        string name, string description, RecipeId recipeId) => new(name, description, recipeId);

    private static void Validate(string name, string description)
    {
        Guard.Against.Requires<CocktailNameCanNotBeEmpty>(string.IsNullOrWhiteSpace(name));
        Guard.Against.Requires<CocktailDescriptionCanNotBeEmpty>(string.IsNullOrWhiteSpace(description));
    }
}