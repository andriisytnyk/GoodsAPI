using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;

namespace GoodsAPI.DAL.Repositories
{
    public class GoodTypeRepository : BaseRepository<GoodType>
    {
        public GoodTypeRepository(GoodsContext goodsContext) : base(goodsContext)
        {

        }

        //Update whole goodType
        public override void Update(int id, GoodType entity)
        {
            var temp = GetById(id);
            temp.Name = entity.Name;
            goodsContext.GoodTypes.Update(temp);
            base.Update(id, temp);
        }

        //Update goodType's name
        public void UpdateGoodTypeName(int id, string name)
        {
            var temp = GetById(id);
            temp.Name = name;
            goodsContext.GoodTypes.Update(temp);
            base.Update(id, temp);
        }
    }
}