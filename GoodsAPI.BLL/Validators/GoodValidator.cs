using FluentValidation;
using GoodsAPI.Shared.DTO;
using System;

namespace GoodsAPI.BLL.Validators
{
    public class GoodValidator : AbstractValidator<GoodDTO>
    {
        public GoodValidator()
        {
            RuleFor(g => g.Name).NotNull().NotEmpty().Length(1, 30);
            RuleFor(g => g.Price).GreaterThan(0);
            RuleFor(g => g.Count).GreaterThan(0);
            RuleFor(g => g.GoodType.Name).NotNull().NotEmpty().Length(1, 30);
            RuleFor(g => g.GoodImportance.Name).NotNull().NotEmpty().Length(1, 30);
            RuleFor(g => g.BoughtDate).LessThan(DateTime.Now);
        }
    }
}