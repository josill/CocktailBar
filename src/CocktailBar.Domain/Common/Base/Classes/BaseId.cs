// Copyright (c) 2024 Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

using CocktailBar.Domain.Common.Base.Interfaces;
using CocktailBar.Domain.Common.Errors;
using CocktailBar.Domain.Common.ValueObjects;

namespace CocktailBar.Domain.Common.Base.Classes;

/// <summary>
/// Base class for strongly-typed IDs in the domain.
/// </summary>
/// <typeparam name="TId">The specific ID type.</typeparam>
public abstract class BaseId<TId> : ValueObject<TId>
    where TId : BaseId<TId>, IBaseId<TId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseId{TId}"/> class.
    /// </summary>
    /// <param name="value">The GUID value to use for this ID.</param>
    protected BaseId(Guid value)
    {
        Validate<TId>(value);
        Value = value;
    }

    /// <summary>
    /// Gets the underlying GUID value of the ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Gets the attributes to include in equality checks.
    /// </summary>
    /// <returns>An enumeration of objects representing the attributes to include in equality checks.</returns>
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return Value;
    }

    /// <summary>
    /// Validates the GUID value.
    /// </summary>
    /// <typeparam name="T">The type associated with this ID.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <exception cref="DomainException{T}">Thrown when validation fails.</exception>
    private static void Validate<T>(Guid value)
    {
        DomainException.For<T>(value == Guid.Empty, "ID cannot be empty.");
    }
}
