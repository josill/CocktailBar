// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Api.Common.Errors;
using CocktailBar.Application;
using CocktailBar.Domain.Seedwork;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSingleton<ProblemDetailsFactory, CocktailBarProblemDetailsFactory>();
    builder.Services.AddApplication();
    builder.Services.AddControllers();

    // Optionally add Swagger
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors("origins");
    app.UseExceptionHandler("/error");

    app.Run();
}
