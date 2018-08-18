namespace GoodsAPI.DAL.Models
{
    public class UserGoodType : Entity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int GoodTypeID { get; set; }
        public GoodType GoodType { get; set; }
    }
}