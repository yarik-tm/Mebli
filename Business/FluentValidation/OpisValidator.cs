using Business.DTO;
using FluentValidation;

namespace Business.FluentValidation
{
    public class OpisValidator : AbstractValidator<OpisDTO>
    {
        public OpisValidator()
        {
            RuleFor(desc => desc.Virobnik).NotEmpty();
            RuleFor(desc => desc.Material).NotEmpty();
            RuleFor(desc => desc.MebliID).GreaterThan(0);
        }

    }
}
