// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

public record TestEntityId(Guid Value) : IId<TestEntityId, Guid>
{
    public static TestEntityId New() => new(Guid.NewGuid());

    public static TestEntityId From(Guid id) => new(id);
}

public class TestAggregate : Aggregate<TestEntityId>
{
    public TestAggregate() : base(TestEntityId.New())
    {
    }
}
