// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Api.Common.Errors;
using CocktailBar.Application;
using CocktailBar.Infrastructure;
using CocktailBar.Infrastructure.Cocktails.Context.Write;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
    if (app.Environment.IsDevelopment())
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CocktailsWriteContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors("origins");
    app.UseExceptionHandler("/error");

    app.Run();
}
