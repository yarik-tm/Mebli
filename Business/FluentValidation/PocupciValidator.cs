using Business.DTO;
using FluentValidation;

namespace Business.FluentValidation
{
    public class PocupciValidator : AbstractValidator<PocupciDTO>
    {
        public PocupciValidator()
        {
            RuleFor(pocupci => pocupci.FullName).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty();
        }
    }
}
