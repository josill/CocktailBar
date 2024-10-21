// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Common.Http;

/// <summary>
/// Provides constant keys for storing and retrieving items in the HttpContext.
/// </summary>
public static class HttpContextItemKeys
{
    /// <summary>
    /// The key used to store and retrieve error information in the HttpContext.Items dictionary.
    /// </summary>
    public const string Errors = "errors";
}
