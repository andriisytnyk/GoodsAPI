using FluentValidation;
using GoodsAPI.Shared.DTO;

namespace GoodsAPI.BLL.Validators
{
    public class AccountValidator : AbstractValidator<AccountDTO>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().Length(3, 20);
            RuleFor(a => a.Sum).GreaterThanOrEqualTo(0);
        }
    }
}
