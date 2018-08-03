using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IBillService
    {
        List<BillDTO> GetAll();

        BillDTO GetById(int id);

        void Create(BillDTO bill);

        void Update(int id, BillDTO bill);

        void Delete(BillDTO bill);

        void DeleteById(int id);

        void UpdateBillByAddingAccount(int id, AccountDTO account);

        void UpdateBillByDeletingAccount(int id, decimal sum);
    }
}