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
            RuleFor(u => u.UserBill.Sum).GreaterThanOrEqualTo(0);
            RuleFor(u => u.UserBill.Accounts).Custom((list, context) => {
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
            //RuleFor(u => u.AllGoods).Custom((list, context) =>
            //{
            //    foreach (var item in list)
            //    {
            //        if ((item.Name is null) || (item.Name == "") || (item.Name.Length < 3) || (item.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current name.");
            //        }
            //        if (item.Price <= 0)
            //        {
            //            context.AddFailure("Good is not valid with current price.");
            //        }
            //        if (item.Count <= 0)
            //        {
            //            context.AddFailure("Good is not valid with current count.");
            //        }
            //        if ((item.GoodType.Name is null) || (item.GoodType.Name == "") || (item.GoodType.Name.Length < 3) || (item.GoodType.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current type.");
            //        }
            //        if ((item.GoodImportance.Name is null) || (item.GoodImportance.Name == "") || (item.GoodImportance.Name.Length < 3) || (item.GoodImportance.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current importance.");
            //        }
            //        if (item.BoughtDate > DateTime.Now)
            //        {
            //            context.AddFailure("Good is not valid with current bought date.");
            //        }
            //    }
            //});
            //RuleFor(u => u.UniqueGoods).Custom((list, context) =>
            //{
            //    foreach (var item in list)
            //    {
            //        if ((item.Name is null) || (item.Name == "") || (item.Name.Length < 3) || (item.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current name.");
            //        }
            //        if (item.Price <= 0)
            //        {
            //            context.AddFailure("Good is not valid with current price.");
            //        }
            //        if (item.Count <= 0)
            //        {
            //            context.AddFailure("Good is not valid with current count.");
            //        }
            //        if ((item.GoodType.Name is null) || (item.GoodType.Name == "") || (item.GoodType.Name.Length < 3) || (item.GoodType.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current type.");
            //        }
            //        if ((item.GoodImportance.Name is null) || (item.GoodImportance.Name == "") || (item.GoodImportance.Name.Length < 3) || (item.GoodImportance.Name.Length > 20))
            //        {
            //            context.AddFailure("Good is not valid with current importance.");
            //        }
            //        if (item.BoughtDate > DateTime.Now)
            //        {
            //            context.AddFailure("Good is not valid with current bought date.");
            //        }
            //    }
            //});
            //RuleFor(u => u.UserGoodTypes).Custom((list, context) =>
            //{
            //    foreach (var item in list)
            //    {
            //        if ((item.Name is null) || (item.Name == "") || (item.Name.Length < 3) || (item.Name.Length > 20))
            //        {
            //            context.AddFailure("Type of good is not valid with current name.");
            //        }
            //    }
            //});
        }
    }
}