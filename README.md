-- Product Stock Manager --


Description: 

This is a C# console application for managing product inventory. The program allows users to add, update, search, sort, view, and remove products. 

It also saves product data to a JSON file so that inventory persists between sessions.



Features:

Add Products: Users can enter product name, price, and stock quantity. Duplicate product names are prevented.

Update Stock: Users can restock or reduce stock when items are sold. Negative stock values are prevented.

View Products: Displays all products with name, price, and stock. Users can choose to sort by name, price, or stock quantity.

Search Products: Allows users to find a product by name and display its details.

Remove Products: Deletes a product from inventory.

Persistence: Products are saved to a file called products.json and automatically loaded at startup.

User-Friendly Console: Color-coded messages highlight success, warnings, and errors. Menu navigation is clear and spaced for readability.



Requirements:

.NET 6.0 or later (recommended: .NET 8.0)

C# Dev Kit if using Visual Studio Code



Usage:

Clone or download the project.

Open the folder in Visual Studio Code or another IDE.

Build and run the project using the following commands: dotnet build dotnet run

Use the menu options to manage products:

Add Product

Update Stock

View Products

Remove Product

Search Product

Exit



The program automatically loads existing products from products.json at startup. The file is created after the first product is added.



Project Structure:

Program.cs: Entry point and menu loop

Product.cs: Defines the Product class with attributes Name, Price, and StockQuantity

InventoryManager.cs: Handles product operations (Add, Update, View, Remove, Search) and persistence

products.json: Saved inventory data (auto-generated)

ProductStockManager.csproj: Project file



Future Enhancements:

Low-stock alerts (for example, notify when stock is less than 5)

Reporting features such as total inventory value and average price

Export inventory to CSV for external use

More advanced search options such as partial matches or price ranges