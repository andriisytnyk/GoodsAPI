namespace GoodsAPI.DAL.Models
{
    // Represents entity of one user's account
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
    }
}