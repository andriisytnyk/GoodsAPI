using GoodsAPI.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodsAPI.BLL.Interfaces
{
    public interface IImportanceService
    {
        List<ImportanceDTO> GetAll();

        ImportanceDTO GetById(int id);

        void Create(ImportanceDTO importance);

        void Update(int id, ImportanceDTO importance);

        void Delete(ImportanceDTO importance);

        void DeleteById(int id);

        void UpdateImportanceName(int id, string name);
    }
}
