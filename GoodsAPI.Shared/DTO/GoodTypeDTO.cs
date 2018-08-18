using System.Collections.Generic;

namespace GoodsAPI.Shared.DTO
{
    public class GoodTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}