/*******************************************************************
* Name: Devin Avery
* Date: 10/29/2024
* Assignment: SDC320 Course Project Implementation
*/
//**LIBRARY INCLUSION FOR SQLite DATABASE
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Inventory Management System CLI");
        string db_name = "InventoryDatabase.db";
        var inventoryManager = new InventoryManager(db_name);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Delete Item");
            Console.WriteLine("3. Update Item Quantity");
            Console.WriteLine("4. View All Items");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter item quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        inventoryManager.AddItem(new InventoryItem(0, itemName, quantity));
                        Console.WriteLine("Item added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    }
                    break;

                case "2":
                    Console.Write("Enter the ID of the item to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        inventoryManager.DeleteItem(id);
                        Console.WriteLine("Item deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;

                case "3":
                    Console.Write("Enter the ID of the item to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Enter the new quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int newQuantity))
                        {
                            inventoryManager.UpdateItemQuantity(updateId, newQuantity);
                            Console.WriteLine("Item quantity updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\nAll Items in Inventory:");
                    inventoryManager.PrintAllItems();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}