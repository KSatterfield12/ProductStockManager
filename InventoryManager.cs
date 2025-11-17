using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProductStockManager
{
public class InventoryManager
    {
        private List<Product> products = new List<Product>();
        private const string FileName = "products.json";

        public InventoryManager()
        {
            LoadProducts();
        }

        // Method to add a product
        public void AddProduct()
        {
            Console.Write("\nEnter product name: ");
            string name = Console.ReadLine();

            if (products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nProduct already exists.");
                Console.ResetColor();
                return;
            }

            Console.Write("\nEnter product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid price. Try again.");
                Console.ResetColor();
                return;
            }

            Console.Write("\nEnter stock quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid stock quantity. Try again.");
                Console.ResetColor();
                return;
            }

            products.Add(new Product(name, price, stock));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProduct added successfully!");
            Console.ResetColor();
            SaveProducts();
        }

        // Method to update a product
        public void UpdateStock()
        {
            Console.Write("\nEnter product name to update: ");
            string name = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.Write("\nEnter stock change (positive for restock, negative for sold): ");
                if (!int.TryParse(Console.ReadLine(), out int change))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Try again.");
                    Console.ResetColor();
                    return;
                }

                product.StockQuantity += change;
                if (product.StockQuantity < 0) product.StockQuantity = 0;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStock updated successfully!");
                Console.ResetColor();
                SaveProducts();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduct not found.");
                Console.ResetColor();
            }
        }

        // Method to view the list of products by name, price, or stock quantity 
        public void ViewProducts()
        {
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo products available.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\n--- Product List ---");
            Console.WriteLine("\nSort by: \n1. Name  \n2. Price  \n3. Stock");
            Console.Write("Choose option: ");
            string sortChoice = Console.ReadLine();

            switch (sortChoice)
            {
                case "1":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "2":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "3":
                    products = products.OrderBy(p => p.StockQuantity).ToList();
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Showing unsorted list.");
                    break;
            }

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        // Method to remove products
        public void RemoveProduct()
        {
            Console.Write("\nEnter product name to remove: ");
            string name = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                products.Remove(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nProduct removed successfully!");
                Console.ResetColor();
                SaveProducts();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduct not found.");
                Console.ResetColor();
            }
        }

        // Method to search for a product bt name
        public void SearchProduct()
        {
            Console.Write("\nEnter product name to search: ");
            string name = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nProduct found:\n{product}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduct not found.");
                Console.ResetColor();
            }
        }

        // Method to save and load procudts on startup
        private void SaveProducts()
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(FileName, json);
        }

        private void LoadProducts()
        {
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            }
        }
    }
}