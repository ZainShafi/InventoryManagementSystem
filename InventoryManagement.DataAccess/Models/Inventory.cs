using System;
using System.Collections.Generic;

namespace InventoryManagement.DataAccess.Models
{
    public partial class Inventory
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string Cost { get; set; }

        public virtual UserTable User { get; set; }
    }
}
