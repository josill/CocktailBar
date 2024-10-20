// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
