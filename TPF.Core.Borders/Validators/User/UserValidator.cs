using FluentValidation;
using TPF.Core.Borders.Dtos;

namespace TPF.Core.Borders.Validators.User
{
    public class UserValidator : AbstractValidator<CreateUserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name can't be null or empty");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email can't be null or empty");
            RuleFor(x => x.Secret)
                .NotEmpty()
                .WithMessage("Secret can't be null or empty");
        }
    }
}
