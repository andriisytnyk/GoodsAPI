using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();

        UserDTO GetById(int id);

        void Create(UserDTO user);

        void Update(int id, UserDTO user);

        void Delete(UserDTO user);

        void DeleteById(int id);

        void UpdateLogin(int id, string login);

        void UpdatePassword(int id, string password);

        void UpdateBill(int id, Bill userBill);

        void UpdateAllGoods(int id, List<Good> allGoods);

        void UpdateAllGoodsByAddingGood(int id, Good good);

        void UpdateAllGoodsByAddingGoods(int id, List<Good> goods);

        void UpdateUniqueGoods(int id, List<Good> uniqueGoods);

        void UpdateUniqueGoodsByAddingGood(int id, Good good);

        void UpdateUniqueGoodsByAddingGoods(int id, List<Good> goods);

        void UpdateUserGoodTypes(int id, List<GoodType> userGoodTypes);

        void UpdateUserGoodTypesByAddingType(int id, GoodType goodType);

        void UpdateUserGoodTypesByAddingType(int id, List<GoodType> goodTypes);
    }
}