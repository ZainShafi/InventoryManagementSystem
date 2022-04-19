using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventoryManagement.DataAccess.Models;

namespace InventoryManagement.DataAccess.Providers
{
    public class InventoryProvider
    {
        public List<Inventory> ListInventory()
        {
            using(var dbContext = new INVENTORYMANAGEMENTContext())
            {
                return dbContext.Inventory.ToList();
            }
        }

        public Inventory GetItem(int itemId)
        {
            using (var dbContext = new INVENTORYMANAGEMENTContext())
            {
                var item = (from i in dbContext.Inventory
                            where i.ItemId == itemId
                            select i).FirstOrDefault();
                return item;
            }
        }

        public bool InsertInventory(int itemId, string itemName, int userId, int quantity, string cost)
        {
            try
            {
                using(var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    Inventory inventory = new Inventory();
                    //inventory.ItemId = itemId;
                    inventory.ItemName = itemName;
                    inventory.UserId = userId;
                    inventory.Quantity = quantity;
                    inventory.Cost = cost;
                    dbContext.Inventory.Add(inventory);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }

        public bool UpdateInventory(int itemId, int quantity, string cost)
        {
            try
            {
                using (var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    var item = (from b in dbContext.Inventory
                                where b.ItemId == itemId
                                select b).FirstOrDefault();
                    item.Quantity = quantity;
                    item.Cost = cost;
                    dbContext.Inventory.Update(item);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }


        public bool DeleteInventory(int itemId, string itemName, int userId, int quantity, string cost)
        {
            try
            {
                using (var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    var item = (from b in dbContext.Inventory
                                where b.ItemId == itemId
                                select b).FirstOrDefault();
                    item.ItemId = itemId;
                    item.ItemName = itemName;
                    item.UserId = userId;
                    item.Quantity = quantity;
                    item.Cost = cost;
                    dbContext.Inventory.Remove(item);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }
    }
}
