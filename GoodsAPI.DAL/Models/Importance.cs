using System.Collections.Generic;

namespace GoodsAPI.DAL.Models
{
    public class Importance : Entity
    {
        public string Name { get; set; }
        public List<UserImportance> UserImportances { get; set; }

        public Importance()
        {
            UserImportances = new List<UserImportance>();
        }
    }
}