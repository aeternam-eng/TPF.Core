using FluentValidation;

namespace TPF.Core.Borders.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Guid can't be null or empty");
        }
    }
}
