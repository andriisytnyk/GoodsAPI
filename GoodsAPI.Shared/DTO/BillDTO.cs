﻿using System.Collections.Generic;

namespace GoodsAPI.Shared.DTO
{
    // Represents entity of user's bill, that contain all user's accounts
    public class BillDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public List<Account> Accounts { get; set; }
    }
}