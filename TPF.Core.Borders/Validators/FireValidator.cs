using FluentValidation;
using TPF.Core.Borders.Dtos;

namespace TPF.Core.Borders.Validators
{
    public class FireValidator : AbstractValidator<CreateMeasurementRequest>
    {
        public FireValidator()
        {
            RuleFor(x => x.DeviceId)
                .SetValidator(new GuidValidator());
            RuleFor(x => x.Img)
                .NotEmpty()
                .WithMessage("Image can't be null or empty");
        }
    }
}
