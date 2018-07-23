using GoodsAPI.Shared.DTO;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IGoodTypeService
    {
        List<GoodTypeDTO> GetAll();

        GoodTypeDTO GetById(int id);

        void Create(GoodTypeDTO goodType);

        void Update(int id, GoodTypeDTO goodType);

        void Delete(GoodTypeDTO goodType);

        void DeleteById(int id);

        void UpdateGoodTypeName(int id, string name);
    }
}