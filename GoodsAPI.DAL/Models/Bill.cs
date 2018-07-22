using System.Collections.Generic;

namespace GoodsAPI.DAL.Models
{
    // Represents entity of user's bill, that contain all user's accounts
    public class Bill : Entity
    {
        public decimal Sum { get; set; }
        public List<Account> Accounts { get; set; }
    }
}