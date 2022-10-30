using FluentValidation;
using TPF.Core.Shared.Models;

namespace TPF.Core.Shared.Extensions;

public static class ValidationExceptionExtensions
{
    public static IEnumerable<ErrorMessage> ToErrorsMessage(this ValidationException exception)
    {
        return exception.Errors.Select(error => new ErrorMessage(error.ErrorCode, error.ErrorMessage));
    }
}
