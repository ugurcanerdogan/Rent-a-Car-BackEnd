using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.CustomerId).NotEmpty();
            RuleFor(cu => cu.CompanyName).NotEmpty();
            RuleFor(cu => cu.CompanyName).MinimumLength(2);
            RuleFor(cu => cu.UserId).NotEmpty();
        }
    }
}
