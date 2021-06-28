using Business.DTO;
using FluentValidation;


namespace Business.FluentValidation
{
    public class RobitnikiValidator : AbstractValidator<RobitnikiDTO>
    {
       public RobitnikiValidator()
        {
            RuleFor(robitniki => robitniki.FullName).NotEmpty();
            RuleFor(robitniki => robitniki.Staj).GreaterThan(0);
        }
    }
}
