using System.Collections.Generic;

namespace GoodsAPI.Shared.DTO
{
    // Represents entity of user
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Bill UserBill { get; set; }
        public List<Good> AllGoods { get; set; }
        public List<Good> UniqueGoods { get; set; }
        public List<GoodType> UserGoodTypes { get; set; }
    }
}