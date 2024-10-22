// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
}

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
