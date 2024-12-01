// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace CocktailBar.Domain.Seedwork;

public readonly record struct TestEntityId
{
    private TestEntityId(Guid value) => Value = value;

    public Guid Value { get; }

    public static TestEntityId New() => new(Guid.NewGuid());

    public static TestEntityId From(Guid id) => new(id);
}

public class TestAggregate : Aggregate<TestEntityId>
{
    public TestAggregate() : base(TestEntityId.New())
    {
    }
}
