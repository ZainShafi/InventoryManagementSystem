using System;

namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Inventory Management System!");
            try
            {
                switch (args[0].ToLower())
                {
                    case "inventory":
                        new InventoryCommand().ExecuteCommand(args);
                        break;
                    case "user":
                        new UserCommand().ExecuteCommand(args);
                        break;
                    default:
                        Console.Out.WriteLine("Invalid Command.");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine("Error in System"+ex.Message);
            }            
        }
    }
}
