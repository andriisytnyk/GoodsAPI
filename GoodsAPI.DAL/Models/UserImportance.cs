namespace GoodsAPI.DAL.Models
{
    public class UserImportance
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int ImportanceID { get; set; }
        public Importance Importance { get; set; }
    }
}