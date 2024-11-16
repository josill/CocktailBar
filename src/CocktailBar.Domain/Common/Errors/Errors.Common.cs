// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using ErrorOr;

namespace CocktailBar.Domain.Common.Errors;

public static partial class Errors
{
    public static class Common
    {
        public static Error SomethingWentWrong(string message) => Error.Unexpected("Common.SomethingWentWrong", message);
    }
}
