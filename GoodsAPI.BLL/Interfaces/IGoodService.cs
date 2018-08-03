using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IGoodService
    {
        List<GoodDTO> GetAll();

        GoodDTO GetById(int id);

        void Create(GoodDTO good);

        void Update(int id, GoodDTO good);

        void Delete(GoodDTO good);

        void DeleteById(int id);

        void UpdateGoodByChangingName(int id, string name);

        void UpdateGoodByChangingPrice(int id, decimal price);

        void UpdateGoodByChangingCount(int id, float count);

        void UpdateGoodByChangingType(int id, GoodTypeDTO goodType);

        void UpdateGoodByChangingImportance(int id, ImportanceDTO goodImportance);

        void UpdateGoodByChangingBoughtDate(int id, DateTime boughtDate);
    }
}