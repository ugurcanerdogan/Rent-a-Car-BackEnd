using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(co => co.ColorName).NotEmpty();
            RuleFor(co => co.ColorName).MinimumLength(2);
        }
    }
}
