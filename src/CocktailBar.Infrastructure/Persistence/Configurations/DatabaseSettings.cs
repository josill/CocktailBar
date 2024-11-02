// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Configurations;

public class DatabaseSettings
{
    public const string SectionName = "DatabaseSettings";

    public bool RecreateOnStartup { get; set; }
}
