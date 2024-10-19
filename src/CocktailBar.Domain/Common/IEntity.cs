using System.ComponentModel.DataAnnotations;

namespace CocktailBar.Domain.Base;

public interface IEntity<out TId>
{
    TId Id { get; }
}