using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.DataAccess.Models;
using InventoryManagement.DataAccess.Providers;

namespace InventoryManagement
{
    public class InventoryCommand
    {
        public void ExecuteCommand(string[] args)
        {
            switch(args[1].ToLower())
            {
                case "list":
                    ListInventory();
                    break;
                case "insert":
                    InsertInventory(int.Parse(args[2]), args[3], int.Parse(args[4]), int.Parse(args[5]), args[6]);
                    break;
                case "update":
                    UpdateInventory(int.Parse(args[2]), int.Parse(args[3]), args[4]);
                    break;
                case "delete":
                    DeleteInventory(int.Parse(args[2]), args[3], int.Parse(args[4]), int.Parse(args[5]), args[6]);
                    break;
                case "item-details":
                    GetItem(int.Parse(args[2]));
                    break;

            }
        }

        private void ListInventory()
        {
            InventoryProvider inventoryProvider = new InventoryProvider();
            List<Inventory> inventory = inventoryProvider.ListInventory();
            foreach(Inventory inventory1 in inventory)
            {
                Console.Out.WriteLine("Item ID:"+inventory1.ItemId);
                Console.Out.WriteLine("Item Name:"+inventory1.ItemName);
                Console.Out.WriteLine("User ID:"+inventory1.UserId);
                Console.Out.WriteLine("Quantity:"+inventory1.Quantity);
                Console.Out.WriteLine("Cost:"+inventory1.Cost);
                Console.Out.WriteLine("*******************************");
            }
        }

        private void GetItem(int itemId)
        {
            InventoryProvider inventoryProvider = new InventoryProvider();
            Inventory inventory = inventoryProvider.GetItem(itemId);
            Console.Out.WriteLine("Item ID:" + inventory.ItemId);
            Console.Out.WriteLine("Item Name:" + inventory.ItemName);
            Console.Out.WriteLine("User ID:" + inventory.UserId);
            Console.Out.WriteLine("Quantity:" + inventory.Quantity);
            Console.Out.WriteLine("Cost:" + inventory.Cost);
        }

        private void InsertInventory(int itemId, string itemName, int userId, int quantity, string cost)
        {
            InventoryProvider inventoryProvider = new InventoryProvider();
            bool insertResult = inventoryProvider.InsertInventory(itemId, itemName, userId, quantity, cost);
            if(insertResult)
            {
                Console.Out.WriteLine("Inventory Items Added Successfully!");
            }
        }

        private void UpdateInventory(int itemId, int quantity, string cost)
        {
            InventoryProvider inventoryProvider = new InventoryProvider();
            bool updateResult = inventoryProvider.UpdateInventory(itemId, quantity, cost);
            if (updateResult)
            {
                Console.Out.WriteLine("Inventory Items Updated Successfully!");
            }
        }


        private void DeleteInventory(int itemId, string itemName, int userId, int quantity, string cost)
        {
            InventoryProvider inventoryProvider = new InventoryProvider();
            bool DeleteResult = inventoryProvider.DeleteInventory(itemId,itemName,userId ,quantity, cost);
            if (DeleteResult)
            {
                Console.Out.WriteLine("Inventory Items Deleted Successfully!");
            }
        }
    }
}
