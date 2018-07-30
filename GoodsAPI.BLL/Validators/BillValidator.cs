using FluentValidation;
using GoodsAPI.Shared.DTO;

namespace GoodsAPI.BLL.Validators
{
    public class BillValidator : AbstractValidator<BillDTO>
    {
        public BillValidator()
        {
            RuleFor(b => b.Sum).GreaterThanOrEqualTo(0);
            RuleFor(b => b.Accounts).Custom((list, context) => {
                foreach (var item in list)
                {
                    if ((item.Name is null) || (item.Name == "") || (item.Name.Length < 3) || (item.Name.Length > 20))
                    {
                        context.AddFailure("Account is not valid with current name.");
                    }
                    if (item.Sum < 0)
                    {
                        context.AddFailure("Account is not valid with current sum.");
                    }
                }
            });
        }
    }
}