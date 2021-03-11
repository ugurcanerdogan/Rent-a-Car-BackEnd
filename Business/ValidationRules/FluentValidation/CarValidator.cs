using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage(Messages.CarNameLengthError);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceMinimumError);
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}
