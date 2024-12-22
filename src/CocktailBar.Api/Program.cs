// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Api.Common.Errors;
using CocktailBar.Application;
using CocktailBar.Domain.Aggregates.Recipe;
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

        var recipeIngredients = RecipeIngredientsSeedConfiguration.GetSeedData().ToList();
        Console.WriteLine(recipeIngredients.Count);
        context.RecipeIngredients.AddRange(recipeIngredients);
        context.SaveChanges();
    }

    app.Run();
}
