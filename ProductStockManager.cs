using System;

namespace ProductStockManager
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Parameterless constructor for JSON deserialization
        public Product() { }

        public Product(string name, decimal price, int stockQuantity)
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price:C}, Stock: {StockQuantity}";
        }
    }
}