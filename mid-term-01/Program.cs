public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // TODO: Initialize the properties with the values passed to the constructor.
        this.ItemName = itemName;
        this.ItemId = itemId;
        this.Price = price;
        this.QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // TODO: Update the item's price with the new price.
        this.Price += newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // TODO: Increase the item's stock quantity by the additional quantity.
        this.QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // TODO: Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
        if (QuantityInStock >= quantitySold)
        {
            this.QuantityInStock -= quantitySold;
        }
        else
        {
            Console.WriteLine("Stock Not available");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // TODO: Return true if the item is in stock (quantity > 0), otherwise false.
        return this.QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        // TODO: Print the details of the item (name, id, price, and stock quantity).
        Console.WriteLine($"Item Name: {this.ItemName}, Item ID: {this.ItemId}, Price: {this.Price}, Quantity in Stock: {this.QuantityInStock}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1500.20, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 950.30, 15);

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 1. Print details of all items.
        item1.PrintDetails();
        item2.PrintDetails();

        Console.WriteLine("Do you wish to 'Sell' or 'Restock' the item");
        string action = Console.ReadLine().Trim().ToLower();

        Console.WriteLine("Which item would you like to update 1 or 2");
        int itemChoice = int.Parse(Console.ReadLine());

        InventoryItem selectedItem = itemChoice == 1 ? item1 : item2;


        if (action == "sell")
        {
            Console.WriteLine("Enter the quantity to sell:");
            int quantity = int.Parse(Console.ReadLine());
            selectedItem.SellItem(quantity);
        }
        else if (action == "restock")
        {
            Console.WriteLine("Enter the quantity to restock:");
            int quantity = int.Parse(Console.ReadLine());
            selectedItem.RestockItem(quantity);
        }
        else
        {
            Console.WriteLine("Invalid action.");
        }

        // Display the updated inventory status
        Console.WriteLine("\nUpdated Inventory Status:");
        item1.PrintDetails();
        item2.PrintDetails();

        // 2. Sell some items and then print the updated details.

    }
}