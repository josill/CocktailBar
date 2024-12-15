namespace CocktailBar.Domain.Aggregates.Ingredient;

/// <summary>
/// Represents the name of an ingredient in the cocktail bar system.
/// </summary>
public record IngredientName
{
    /// <summary>
    /// Gets or sets the trimmed name of the ingredient.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientName"/> class.
    /// </summary>
    /// <param name="value">The ingredient name to store.</param>
    public IngredientName(string value)
    {
        Value = value.Trim();
    }
}
