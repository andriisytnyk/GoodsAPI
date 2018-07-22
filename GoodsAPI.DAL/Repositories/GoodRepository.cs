using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;
using System;

namespace GoodsAPI.DAL.Repositories
{
    public class GoodRepository : BaseRepository<Good>
    {
        public GoodRepository(GoodsContext goodsContext) : base(goodsContext)
        {

        }

        //Update whole good
        public override void Update(int id, Good entity)
        {
            var temp = GetById(id);
            temp.Name = entity.Name;
            temp.Price = entity.Price;
            temp.Count = entity.Count;
            temp.GoodType = entity.GoodType;
            temp.GoodImportance = entity.GoodImportance;
            temp.BoughtDate = entity.BoughtDate;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update good's name
        public void UpdateGoodByChangingName(int id, string name)
        {
            var temp = GetById(id);
            temp.Name = name;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update good's price
        public void UpdateGoodByChangingPrice(int id, decimal price)
        {
            var temp = GetById(id);
            temp.Price = price;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update count of goods
        public void UpdateGoodByChangingCount(int id, float count)
        {
            var temp = GetById(id);
            temp.Count = count;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update good's type
        public void UpdateGoodByChangingType(int id, GoodType goodType)
        {
            var temp = GetById(id);
            temp.GoodType = goodType;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update good's importance
        public void UpdateGoodByChangingImportance(int id, Importance goodImportance)
        {
            var temp = GetById(id);
            temp.GoodImportance = goodImportance;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }

        //Update good's bought date
        public void UpdateGoodByChangingBoughtDate(int id, DateTime boughtDate)
        {
            var temp = GetById(id);
            temp.BoughtDate = boughtDate;
            goodsContext.Goods.Update(temp);
            base.Update(id, temp);
        }
    }
}