using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;

namespace GoodsAPI.DAL.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(GoodsContext db) : base(db)
        {
            
        }

        //Update whole account
        public override void Update(int id, Account entity)
        {
            var temp = GetById(id);
            temp.Name = entity.Name;
            temp.Sum = entity.Sum;
            goodsContext.Accounts.Update(temp);
            base.Update(id, temp);
        }

        //Update account's name
        public void UpdateAccountByChangingName(int id, string name)
        {
            var temp = GetById(id);
            temp.Name = name;
            goodsContext.Accounts.Update(temp);
            base.Update(id, temp);
        }

        //Update account's sum
        public void UpdateByChangingSum(int id, decimal sum)
        {
            var temp = GetById(id);
            temp.Sum = sum;
            goodsContext.Accounts.Update(temp);
            base.Update(id, temp);
        }
    }
}