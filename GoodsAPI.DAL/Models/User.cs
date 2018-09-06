using System.Collections.Generic;

namespace GoodsAPI.DAL.Models
{
    // Represents entity of user
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Bill UserBill { get; set; }
        public List<Good> AllGoods { get; set; }
        public List<UserGoodType> UserGoodTypes { get; set; }
        public List<UserImportance> UserImportances { get; set; }

        public User()
        {
            AllGoods = new List<Good>();
            UserGoodTypes = new List<UserGoodType>();
            UserImportances = new List<UserImportance>();
        }
    }
}