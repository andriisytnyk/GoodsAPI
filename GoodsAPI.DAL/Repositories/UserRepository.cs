using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;
using System.Collections.Generic;

namespace GoodsAPI.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(GoodsContext goodsContext) : base(goodsContext)
        {

        }

        //Update whole user
        public override void Update(int id, User entity)
        {
            var temp = GetById(id);
            temp.Login = entity.Login;
            temp.Password = entity.Password;
            temp.UserBill = entity.UserBill;
            temp.AllGoods = entity.AllGoods;
            //temp.UniqueGoods = entity.UniqueGoods;
            temp.UserGoodTypes = entity.UserGoodTypes;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's login
        public void UpdateLogin(int id, string login)
        {
            var temp = GetById(id);
            temp.Login = login;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's password
        public void UpdatePassword(int id, string password)
        {
            var temp = GetById(id);
            temp.Password = password;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's bill
        public void UpdateBill(int id, Bill userBill)
        {
            var temp = GetById(id);
            temp.UserBill = userBill;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        #region UpdateAllGoods
        
        //Update user's list of all goods by replacing with another list
        public void UpdateAllGoods(int id, List<Good> allGoods)
        {
            var temp = GetById(id);
            temp.AllGoods = allGoods;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's list of all goods by adding new good
        public void UpdateAllGoodsByAddingGood(int id, Good good)
        {
            var temp = GetById(id);
            temp.AllGoods.Add(good);
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's list of all goods by adding new list of goods
        public void UpdateAllGoodsByAddingGoods(int id, List<Good> goods)
        {
            var temp = GetById(id);
            foreach (var item in goods)
            {
                temp.AllGoods.Add(item);
            }
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }
        
        #endregion

        //#region UpdateUniqueGoods
        
        ////Update user's list of unique goods by replacing with another list
        //public void UpdateUniqueGoods(int id, List<Good> uniqueGoods)
        //{
        //    var temp = GetById(id);
        //    temp.UniqueGoods = uniqueGoods;
        //    goodsContext.Users.Update(temp);
        //    base.Update(id, temp);
        //}

        ////Update user's list of unique goods by adding new good
        //public void UpdateUniqueGoodsByAddingGood(int id, Good good)
        //{
        //    var temp = GetById(id);
        //    temp.UniqueGoods.Add(good);
        //    goodsContext.Users.Update(temp);
        //    base.Update(id, temp);
        //}

        ////Update user's list of unique goods by adding new list of goods
        //public void UpdateUniqueGoodsByAddingGoods(int id, List<Good> goods)
        //{
        //    var temp = GetById(id);
        //    foreach (var item in goods)
        //    {
        //        temp.AllGoods.Add(item);
        //    }
        //    goodsContext.Users.Update(temp);
        //    base.Update(id, temp);
        //}
        
        //#endregion

        #region UpdateUserGoodTypes
        
        //Update user's list of goodTypes by replacing with another list
        public void UpdateUserGoodTypes(int id, List<GoodType> userGoodTypes)
        {
            var temp = GetById(id);
            temp.UserGoodTypes = userGoodTypes;
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's list of goodTypes by adding new goodType
        public void UpdateUserGoodTypesByAddingType(int id, GoodType goodType)
        {
            var temp = GetById(id);
            temp.UserGoodTypes.Add(goodType);
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }

        //Update user's list of goodTypes by adding new list of goodTypes
        public void UpdateUserGoodTypesByAddingTypes(int id, List<GoodType> goodTypes)
        {
            var temp = GetById(id);
            foreach (var item in goodTypes)
            {
                temp.UserGoodTypes.Add(item);
            }
            goodsContext.Users.Update(temp);
            base.Update(id, temp);
        }
        
        #endregion
    }
}