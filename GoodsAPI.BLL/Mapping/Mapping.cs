using GoodsAPI.DAL.Models;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using GoodsAPI.BLL.Interfaces;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Mapping
{
    public class Mapping : IMapper
    {
        private readonly AccountRepository accRepo;
        private readonly BillRepository billRepo;
        private readonly GoodRepository goodRepo;
        private readonly GoodTypeRepository goodTypeRepo;
        private readonly ImportanceRepository impRepo;
        private readonly UserRepository userRepo;

        public Mapping(AccountRepository accRepo, BillRepository billRepo, GoodRepository goodRepo, 
            GoodTypeRepository goodTypeRepo, ImportanceRepository impRepo, UserRepository userRepo)
        {
            this.accRepo = accRepo;
            this.billRepo = billRepo;
            this.goodRepo = goodRepo;
            this.goodTypeRepo = goodTypeRepo;
            this.impRepo = impRepo;
            this.userRepo = userRepo;
        }

        public AccountDTO MapAccount(Account value)
        {
            return new AccountDTO()
            {
                Id = value.Id,
                Name = value.Name,
                Sum = value.Sum
            };
        }

        public Account MapAccount(AccountDTO value)
        {
            return new Account()
            {
                Id = value.Id,
                Name = value.Name,
                Sum = value.Sum
            };
        }

        public BillDTO MapBill(Bill value)
        {
            var list = new List<AccountDTO>();
            if (value.Accounts != null)
            {
                foreach (var item in value.Accounts)
                    list.Add(MapAccount(item));
            }
            return new BillDTO
            {
                Id = value.Id,
                Sum = value.Sum,
                Accounts = list
            };
        }

        public Bill MapBill(BillDTO value)
        {
            var listAcc = accRepo.GetAll();
            var list = new List<Account>();
            if (value.Accounts != null)
            {
                foreach (var item in value.Accounts)
                {
                    foreach (var acc in listAcc)
                    {
                        if (item.Id == acc.Id)
                        {
                            list.Add(acc);
                            goto Next;
                        }
                    }
                    Next:;
                }
            }
            return new Bill
            {
                Id = value.Id,
                Sum = value.Sum,
                Accounts = list
            };
        }

        public GoodDTO MapGood(Good value)
        {
            return new GoodDTO
            {
                Id = value.Id,
                Name = value.Name,
                Price = value.Price,
                Count = value.Count,
                GoodType = MapGoodType(value.GoodType),
                GoodImportance = MapImportance(value.GoodImportance),
                BoughtDate = value.BoughtDate
            };
        }

        public Good MapGood(GoodDTO value)
        {
            return new Good
            {
                Id = value.Id,
                Name = value.Name,
                Price = value.Price,
                Count = value.Count,
                GoodType = MapGoodType(value.GoodType),
                GoodImportance = MapImportance(value.GoodImportance),
                BoughtDate = value.BoughtDate
            };
        }

        public GoodTypeDTO MapGoodType(GoodType value)
        {
            return new GoodTypeDTO
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public GoodType MapGoodType(GoodTypeDTO value)
        {
            return new GoodType
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public ImportanceDTO MapImportance(Importance value)
        {
            return new ImportanceDTO
            {
                Id = value.Id,
                Name = value.Name,
                UserImportances = value.UserImportances
            };
        }

        public Importance MapImportance(ImportanceDTO value)
        {
            return new Importance
            {
                Id = value.Id,
                Name = value.Name,
                UserImportances = value.UserImportances
            };
        }

        public UserDTO MapUser(User value)
        {
            var listGoods = new List<GoodDTO>();
            if (value.AllGoods != null)
            {
                foreach (var item in value.AllGoods)
                    listGoods.Add(MapGood(item));
            }
            //var listGoodTypes = new List<GoodTypeDTO>();
            //if (value.GoodTypes != null)
            //{
            //    foreach (var item in value.GoodTypes)
            //        listGoodTypes.Add(MapGoodType(item));
            //}
            return new UserDTO
            {
                Id = value.Id,
                Login = value.Login,
                Password = value.Password,
                UserBill = MapBill(value.UserBill),
                AllGoods = listGoods,
                //UserGoodTypes = listGoodTypes
                UserImportances = value.UserImportances
            };
        }

        public User MapUser(UserDTO value)
        {
            var listGoods = goodRepo.GetAll();
            var listUserGoods = new List<Good>();
            if (value.AllGoods != null)
            {
                foreach (var item in value.AllGoods)
                {
                    foreach (var good in listGoods)
                    {
                        if (item.Id == good.Id)
                        {
                            listUserGoods.Add(good);
                            goto Next1;
                        }
                    }
                    Next1:;
                }
            }
            var listGoodTypes = goodTypeRepo.GetAll();
            var listUserGoodTypes = new List<GoodType>();
            if (value.GoodTypes != null)
            {
                foreach (var item in value.GoodTypes)
                {
                    foreach (var goodType in listGoodTypes)
                    {
                        if (item.Id == goodType.Id)
                        {
                            listUserGoodTypes.Add(goodType);
                            goto Next1;
                        }
                    }
                    Next1:;
                }
            }
            return new User
            {
                Id = value.Id,
                Login = value.Login,
                Password = value.Password,
                UserBill = MapBill(value.UserBill),
                AllGoods = listUserGoods,
                //GoodTypes = listUserGoodTypes
                UserImportances = value.UserImportances
            };
        }
    }
}