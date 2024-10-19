using Ardalis.GuardClauses;
using CocktailBar.Domain.Base;
using CocktailBar.Domain.Cocktail.ValueObjects.Ids;

namespace CocktailBar.Domain.Cocktail.Entities;

public class Recipe : EntityWithMetadata<RecipeId>
{
    private readonly List<Ingredient> _ingredients = new();

    public string Instructions { get; }
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.ToList().AsReadOnly(); // .ToList creates a copy of the object because .AsReadOnly you can still cast it back and edit the original readonly object 
    
    private Recipe(string instructions) : base(RecipeId.CreateUnique())
    {
        Instructions = instructions;
    }

    private static Recipe Create(string instructions) => new(instructions);

    private static void Validate(string instructions)
    {
        Guard.Against.Requires<RecipeInstructionsCannotBeEmpty>(string.IsNullOrWhiteSpace(instructions));
    }
 }