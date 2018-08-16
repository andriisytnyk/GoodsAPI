using FluentValidation;
using GoodsAPI.Shared.DTO;
using System;

namespace GoodsAPI.BLL.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.Login).NotNull().NotEmpty().Length(1, 20);
            RuleFor(u => u.Password).NotNull().NotEmpty().Length(8, 30);
        }
    }
}