// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Infrastructure.Persistence.Models;

public sealed record CocktailReadModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Desciption { get; set; }
}
