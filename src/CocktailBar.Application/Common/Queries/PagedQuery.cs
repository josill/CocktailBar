using ErrorOr;
using MediatR;

namespace CocktailBar.Application.Common.Queries;

public record PagedQuery<TResult>(int Page, int PageSize) : IRequest<ErrorOr<TResult>>;
