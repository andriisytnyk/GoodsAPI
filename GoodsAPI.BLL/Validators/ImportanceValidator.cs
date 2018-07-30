using FluentValidation;
using GoodsAPI.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsAPI.BLL.Validators
{
    public class ImportanceValidator : AbstractValidator<ImportanceDTO>
    {
        public ImportanceValidator()
        {
            RuleFor(i => i.Name).NotNull().NotEmpty().Length(3, 30);
        }
    }
}