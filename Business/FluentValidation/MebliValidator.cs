using Business.DTO;
using FluentValidation;


namespace Business.FluentValidation
{
    public class MebliValidator : AbstractValidator<MebliDTO>
    {
        public MebliValidator()
        {
            RuleFor(mebli => mebli.Price).GreaterThan(0).NotNull();
            RuleFor(mebli => mebli.ProdavecID).GreaterThan(0).NotNull();
        }
    }
}
