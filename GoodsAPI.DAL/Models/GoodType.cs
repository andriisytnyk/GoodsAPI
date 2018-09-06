using System.Collections.Generic;

namespace GoodsAPI.DAL.Models
{
    public class GoodType : Entity
    {
        public string Name { get; set; }
        public List<UserGoodType> UserGoodTypes { get; set; }

        public GoodType()
        {
            UserGoodTypes = new List<UserGoodType>();
        }
    }
}