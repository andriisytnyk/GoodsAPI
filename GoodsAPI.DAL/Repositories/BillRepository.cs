using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;

namespace GoodsAPI.DAL.Repositories
{
    public class BillRepository : BaseRepository<Bill>
    {
        public BillRepository(GoodsContext goodsContext) : base(goodsContext)
        {

        }

        //Update whole bill
        public override void Update(int id, Bill entity)
        {
            var temp = GetById(id);
            temp.Sum = entity.Sum;
            temp.Accounts = entity.Accounts;
            goodsContext.Bills.Update(temp);
            base.Update(id, temp);
        }

        //Update bill by adding new account
        public void UpdateBillByAddingAccount(int id, Account account)
        {
            var temp = GetById(id);
            temp.Accounts.Add(account);
            temp.Sum += account.Sum;
            goodsContext.Bills.Update(temp);
            base.Update(id, temp);
        }

        //Update bill by deleting account
        public void UpdateBillByDeletingAccount(int id, decimal sum)
        {
            var temp = GetById(id);
            temp.Sum -= sum;
            goodsContext.Bills.Update(temp);
            base.Update(id, temp);
        }
    }
}