using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

 namespace ProductStockManager
{   
    // Command line interface main method
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Product Stock Manager ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.AddProduct();
                        break;
                    case "2":
                        manager.UpdateStock();
                        break;
                    case "3":
                        manager.ViewProducts();
                        break;
                    case "4":
                        manager.RemoveProduct();
                        break;
                    case "5":
                        manager.SearchProduct();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice. Try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}