// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Common.Settings;

/// <summary>
/// Represents configuration settings for the database in the CocktailBar application.
/// Used to configure database behavior and startup options.
/// </summary>
public class DatabaseSettings
{
    /// <summary>
    /// The configuration section name for database settings in the application configuration.
    /// Used to bind configuration values from appsettings.json or other configuration sources.
    /// </summary>
    public const string SectionName = "DatabaseSettings";

    /// <summary>
    /// Gets or sets a value indicating whether the database should be recreated when the application starts.
    /// When true, the database will be dropped and recreated during application startup.
    /// </summary>
    public bool RecreateOnStartup { get; set; }
}