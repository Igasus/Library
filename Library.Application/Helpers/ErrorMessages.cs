using System.Linq.Expressions;
using Library.Application.Extensions;

namespace Library.Application.Helpers;

public class ErrorMessages
{
    public static string NotFound<T, TMember>(Expression<Func<T, TMember>> memberAccess, TMember memberValue)
    {   
        var objDescription = $"{{ {ObjectExtensions.GetMemberName(default, memberAccess)}: {memberValue} }}";
        var message = $"{typeof(T).Name} {objDescription} does not exist.";

        return message;
    }
}