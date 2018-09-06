using GoodsAPI.DAL.Models;
using System.Collections.Generic;

namespace GoodsAPI.Shared.DTO
{
    public class ImportanceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserImportance> UserImportances { get; set; }

        public ImportanceDTO()
        {
            UserImportances = new List<UserImportance>();
        }
    }
}