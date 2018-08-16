using FluentValidation;
using GoodsAPI.Shared.DTO;

namespace GoodsAPI.BLL.Validators
{
    public class BillValidator : AbstractValidator<BillDTO>
    {
        public BillValidator()
        {
            RuleFor(b => b.Sum).GreaterThanOrEqualTo(0);
        }
    }
}