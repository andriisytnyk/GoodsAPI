using GoodsAPI.DAL.Models;
using System.Collections.Generic;

namespace GoodsAPI.Shared.DTO
{
    // Represents entity of user
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public BillDTO UserBill { get; set; }
        public List<GoodDTO> AllGoods { get; set; }
        public List<GoodTypeDTO> GoodTypes { get; set; }
        public List<UserImportance> UserImportances { get; set; }

        public UserDTO()
        {
            AllGoods = new List<GoodDTO>();
            GoodTypes = new List<GoodTypeDTO>();
            UserImportances = new List<UserImportance>();
        }
    }
}