using GoodsAPI.Shared.DTO;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();

        UserDTO GetById(int id);

        int Create(UserDTO user);

        void Update(int id, UserDTO user);

        void Delete(UserDTO user);

        void DeleteById(int id);

        void UpdateLogin(int id, string login);

        void UpdatePassword(int id, string password);

        void UpdateBill(int id, BillDTO userBill);

        void UpdateAllGoods(int id, List<GoodDTO> allGoods);

        void UpdateAllGoodsByAddingGood(int id, GoodDTO good);

        void UpdateAllGoodsByAddingGoods(int id, List<GoodDTO> goods);

        void UpdateUserGoodTypes(int id, List<GoodTypeDTO> userGoodTypes);

        void UpdateUserGoodTypesByAddingType(int id, GoodTypeDTO goodType);

        void UpdateUserGoodTypesByAddingTypes(int id, List<GoodTypeDTO> goodTypes);
    }
}