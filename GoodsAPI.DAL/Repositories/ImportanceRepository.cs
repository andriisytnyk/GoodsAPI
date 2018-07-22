using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Models;

namespace GoodsAPI.DAL.Repositories
{
    public class ImportanceRepository : BaseRepository<Importance>
    {
        public ImportanceRepository(GoodsContext goodsContext) : base(goodsContext)
        {

        }

        //Update whole importance
        public override void Update(int id, Importance entity)
        {
            var temp = GetById(id);
            temp.Name = entity.Name;
            goodsContext.Importances.Update(temp);
            base.Update(id, temp);
        }

        //Update importance's name
        public void UpdateImportanceName(int id, string name)
        {
            var temp = GetById(id);
            temp.Name = name;
            goodsContext.Importances.Update(temp);
            base.Update(id, temp);
        }
    }
}