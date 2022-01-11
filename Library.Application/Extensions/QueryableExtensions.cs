using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Library.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
        Expression<Func<TSource, bool>> predicate, bool condition)
    {
        if (condition)
        {
            source = source.Where(predicate);
        }

        return source;
    }
}