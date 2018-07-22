using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Interfaces;
using GoodsAPI.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodsAPI.DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly GoodsContext goodsContext;

        public BaseRepository(GoodsContext dbContext)
        {
            goodsContext = dbContext;
        }

        public virtual void Create(TEntity entity)
        {
            goodsContext.SetOf<TEntity>().ToList().Add(entity);
            goodsContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            goodsContext.SetOf<TEntity>().ToList().Remove(entity);
            goodsContext.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            goodsContext.SetOf<TEntity>().ToList().RemoveAt(id);
            goodsContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return goodsContext.SetOf<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return goodsContext.SetOf<TEntity>().ToList().SingleOrDefault(i => i.Id == id);
        }

        public virtual void Update(int id, TEntity entity)
        {
            goodsContext.SaveChanges();
        }
    }
}