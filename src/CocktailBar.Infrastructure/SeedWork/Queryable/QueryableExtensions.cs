using CocktailBar.Application.Common.Interfaces.Querying;
using Microsoft.EntityFrameworkCore;

namespace CocktailBar.Infrastructure.SeedWork.Queryable;

public static class QueryableExtensions
{
    public static async Task<IPaginatedList<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> query,
        int page,
        int pageSize)
    {
        var totalCount = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, totalCount, page, pageSize);
    }
}
