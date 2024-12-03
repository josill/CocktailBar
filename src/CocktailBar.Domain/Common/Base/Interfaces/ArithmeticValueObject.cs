using CocktailBar.Domain.Common.ValueObjects;

namespace CocktailBar.Domain.Common.Base.Interfaces;

/// <summary>
/// Interface for value objects that support addition and subtraction
/// </summary>
/// <typeparam name="T">The type of the value object</typeparam>
public interface IArithmeticValueObject<T> : IAddableValueObject<T>, ISubtractableValueObject<T>
    where T : ValueObject<T>
{
}
