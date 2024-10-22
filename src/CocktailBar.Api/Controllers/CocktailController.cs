// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Api.Controllers;

using CocktailBar.Api.Controllers.Common;
using CocktailBar.Contracts.Cocktails;
using Microsoft.AspNetCore.Mvc;

[Route("cocktails")]
public class CocktailController : ApiController
{
    [HttpPost]
    public IActionResult CreateCocktail(CreateCocktailRequest request, string recipeId)
    {
        return Ok(request);
    }
}
