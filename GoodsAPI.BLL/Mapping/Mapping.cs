using AutoMapper;
using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;

namespace GoodsAPI.BLL.Mapping
{
    public class Mapping
    {
        public MapperConfiguration ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<AccountDTO, Account>();

                cfg.CreateMap<Bill, BillDTO>();
                cfg.CreateMap<BillDTO, Bill>();

                cfg.CreateMap<Good, GoodDTO>();
                cfg.CreateMap<GoodDTO, Good>();

                cfg.CreateMap<GoodType, GoodTypeDTO>();
                cfg.CreateMap<GoodTypeDTO, GoodType>();

                cfg.CreateMap<Importance, ImportanceDTO>();
                cfg.CreateMap<ImportanceDTO, Importance>();

                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            }
            );
            return config;
        }
    }
}