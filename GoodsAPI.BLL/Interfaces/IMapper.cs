using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IMapper
    {
        AccountDTO MapAccount(Account value);
        Account MapAccount(AccountDTO value);

        BillDTO MapBill(Bill value);
        Bill MapBill(BillDTO value);

        GoodDTO MapGood(Good value);
        Good MapGood(GoodDTO value);

        GoodTypeDTO MapGoodType(GoodType value);
        GoodType MapGoodType(GoodTypeDTO value);

        ImportanceDTO MapImportance(Importance value);
        Importance MapImportance(ImportanceDTO value);

        UserDTO MapUser(User value);
        User MapUser(UserDTO value);
    }
}