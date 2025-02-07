using CocktailBar.Domain.Enumerations;
using FluentValidation;

namespace CocktailBar.Application.StockOrders.Commands.CreateStockOrder;

public class CreateStockOrderCommandValidator : AbstractValidator<CreateStockOrderCommand>
{
    public CreateStockOrderCommandValidator()
    {
        RuleFor(x => x.OrderNumber).NotEmpty();
        RuleFor(x => x.Price.OrderCost.Amount).GreaterThan(0);
        RuleFor(x => x.Price.OrderCost.Currency)
            .Must(currency => Enum.TryParse<Currency>(currency, true, out _))
            .WithMessage("Currency in incorrect");
        RuleFor(x => x.Price.ShippingCost.Amount).GreaterThan(0);
        RuleFor(x => x.Price.ShippingCost.Currency)
            .Must(currency => Enum.TryParse<Currency>(currency, true, out _))
            .WithMessage("Currency in incorrect");
        RuleFor(x => x.OrderedAtDate).LessThan(DateTime.Now);
        RuleFor(x => x.OrderArriveDate).GreaterThan(DateTime.Now);

        RuleFor(x => x.StockItems)
            .ForEach(si =>
            {
                si.NotNull();
                si.ChildRules(c =>
                {
                    c.RuleFor(x => x.IngredientId).NotEmpty();
                    c.RuleFor(x => x.IngredientId).NotEmpty();
                    c.RuleFor(x => x.IngredientId).NotEmpty();
                });
            });
    }
}
