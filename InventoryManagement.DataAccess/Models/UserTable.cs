using System;
using System.Collections.Generic;

namespace InventoryManagement.DataAccess.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
