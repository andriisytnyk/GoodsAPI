using GoodsAPI.Shared.DTO;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IAccountService
    {
        List<AccountDTO> GetAll();

        AccountDTO GetById(int id);

        int Create(AccountDTO account);

        void Update(int id, AccountDTO account);

        void Delete(AccountDTO account);

        void DeleteById(int id);

        void UpdateAccountByChangingName(int id, string name);

        void UpdateByChangingSum(int id, decimal sum);
    }
}
