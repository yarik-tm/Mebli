using Business.DTO;
using FluentValidation;

namespace Business.FluentValidation
{
    public class ZamovlennyaValidator : AbstractValidator<ZamovlennyaDTO>
    {
        public ZamovlennyaValidator()
        {
            RuleFor(order => order.MebliID).GreaterThan(0);
            RuleFor(order => order.PocupciID).GreaterThan(0);
        }
    }
}
