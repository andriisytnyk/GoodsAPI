namespace GoodsAPI.DAL.Models
{
    // Represents entity of one user's account
    public class Account : Entity
    {
        public string Name { get; set; }
        public decimal Sum { get; set; }
    }
}