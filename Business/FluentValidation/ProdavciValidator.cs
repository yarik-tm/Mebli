using Business.DTO;
using FluentValidation;

namespace Business.FluentValidation
{
    public class ProdavciValidator : AbstractValidator<ProdavciDTO>
    {
        public ProdavciValidator()
        {
            RuleFor(prodavci => prodavci.Email).NotEmpty();
        }
    }
}
