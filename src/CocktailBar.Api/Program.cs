// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Api.Common.Errors;
using CocktailBar.Application;
using CocktailBar.Domain.Aggregates.Ingredient;
using CocktailBar.Domain.Aggregates.Recipe;
using CocktailBar.Domain.Enumerations;
using CocktailBar.Domain.ValueObjects;
using CocktailBar.Infrastructure;
using CocktailBar.Infrastructure.Common.Context;
using CocktailBar.Infrastructure.Seed;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSingleton<ProblemDetailsFactory, CocktailBarProblemDetailsFactory>();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    // Optionally add Swagger
    builder.Services.AddEndpointsApiExplorer();

    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddUserSecrets<Program>();
    }
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors("origins");
    app.UseExceptionHandler("/error");

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // var recipe = RecipeAggregate.Create(Guid.NewGuid(), "Moscow Mule", "instructions");
        // var recipe2 = RecipeAggregate.Create(Guid.NewGuid(), "Skinny Bitch", "instructions");
        // Console.WriteLine(recipe.Id);
        // Console.WriteLine(recipe2.Id);
        // var ingredient = IngredientAggregate.Create("Vodka");
        var recipe = RecipeAggregate.Create(
            RecipeIds.ClassicMartini,
            "Classic Martini",
            """
            1. Fill mixing glass with ice
            2. Add 2.5 oz Tanqueray Gin (or Belvedere Vodka) and 0.5 oz Dry Vermouth
            3. Stir for 30 seconds
            4. Strain into chilled martini glass
            5. Garnish with olives or lemon peel
            """
        );
        recipe.AddIngredient(IngredientIds.GreyGooseVodka, Amount.Create(60, WeightUnit.Ml));

        // var recipeIngredients = RecipeIngredientsSeedConfiguration.GetSeedData().ToList();
        // Console.WriteLine(recipeIngredients.Count);
        // context.RecipeIngredients.AddRange(recipeIngredients);
        context.Recipes.Add(recipe);
        // context.Recipes.Add(recipe2);
        context.SaveChanges();
    }

    app.Run();
}
