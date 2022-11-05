using FluentValidation;
using TPF.Core.Borders.Dtos;

namespace TPF.Core.Borders.Validators
{
    public class FireValidator : AbstractValidator<GetFireRequest>
    {
        public FireValidator()
        {
            RuleFor(x => x.DeviceId)
                .NotEmpty()
                .WithMessage("DeviceId can't be null or empty");
            RuleFor(x => x.Img)
                .NotEmpty()
                .WithMessage("Image can't be null or empty");
        }
    }
}
