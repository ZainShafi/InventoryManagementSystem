using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.DataAccess.Models;
using InventoryManagement.DataAccess.Providers;
using System.Linq;

namespace InventoryManagement
{
    public class UserCommand
    {
        public void ExecuteCommand(string[] args)
        {
            switch(args[1].ToLower())
            {
                case "list":
                    ListUser();
                    break;
                case "insert":
                    InsertUser(int.Parse(args[2]), args[3]);
                    break;
                case "update":
                    UpdateUser(int.Parse(args[2]), args[3]);
                    break;
                case "delete":
                    DeleteUser(int.Parse(args[2]), args[3]);
                    break;
                case "user-details":
                    GetUser(int.Parse(args[2]));
                    break;
                default:
                    Console.Out.WriteLine("Invalid Command!!!");
                    break;
            }
        }

        private void ListUser()
        {
            UserProvider userProvider = new UserProvider();
            List<UserTable> user = userProvider.ListUser();
            foreach (UserTable user1 in user)
            {
                Console.Out.WriteLine("User ID:" + user1.UserId);
                Console.Out.WriteLine("User Name:" + user1.UserName);
                Console.Out.WriteLine("*******************************");
            }
        }

        private void GetUser(int userId)
        {
            UserProvider userProvider = new UserProvider();
            UserTable userTable = userProvider.GetUser(userId);
            Console.Out.WriteLine("User ID:" + userTable.UserId);
            Console.Out.WriteLine("User Name:" + userTable.UserName);
        }

        private void InsertUser(int userId, string userName)
        {
            UserProvider userProvider = new UserProvider();
            bool insertResult = userProvider.InsertUser(userId, userName);
            if (insertResult)
            {
                Console.Out.WriteLine("User Added Successfully!");
            }
        }

        private void UpdateUser(int userId, string userName)
        {
            UserProvider userProvider = new UserProvider();
            bool updateResult = userProvider.UpdateUser(userId, userName);
            if (updateResult)
            {
                Console.Out.WriteLine("User Updated Successfully!");
            }
        }


        private void DeleteUser(int userId, string userName)
        {
            UserProvider userProvider = new UserProvider();
            bool DeleteResult = userProvider.DeleteUser(userId, userName);
            if (DeleteResult)
            {
                Console.Out.WriteLine("User Deleted Successfully!");
            }
        }
    }
}
