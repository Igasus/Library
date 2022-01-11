using System.Linq.Expressions;

namespace Library.Application.Extensions;

public static class ObjectExtensions
{
    public static string GetMemberName<T, TMember>(this T obj, Expression<Func<T, TMember>> memberAccess)
    {
        if (memberAccess.Body is MemberExpression) 
        {
            return ((MemberExpression) memberAccess.Body).Member.Name;
        }

        var operand = ((UnaryExpression) memberAccess.Body).Operand;

        return ((MemberExpression) operand).Member.Name;
    }
}