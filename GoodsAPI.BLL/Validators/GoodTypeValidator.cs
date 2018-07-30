using FluentValidation;
using GoodsAPI.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsAPI.BLL.Validators
{
    public class GoodTypeValidator : AbstractValidator<GoodTypeDTO>
    {
        public GoodTypeValidator()
        {
            RuleFor(gt => gt.Name).NotNull().NotEmpty().Length(3, 30);
        }
    }
}