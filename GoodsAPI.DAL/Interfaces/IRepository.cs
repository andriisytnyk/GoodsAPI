using GoodsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsAPI.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        int Create(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);
    }
}