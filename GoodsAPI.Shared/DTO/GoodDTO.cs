using System;

namespace GoodsAPI.DAL.Models
{
    // Represents entity of user's goods
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Count { get; set; }
        public GoodType GoodType { get; set; }
        public Importance GoodImportance { get; set; }
        public DateTime BoughtDate { get; set; }
    }
}