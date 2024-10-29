//Inventory Manager Class
using System;
using System.Data.SQLite;

public class InventoryManager
{
    private SQLiteConnection connection;

    public InventoryManager(string db_name)
    {
        connection = new SQLiteConnection($"Data Source={db_name};Version=3;");
        connection.Open();
        CreateTable();
    }

    private void CreateTable()
    {
        string createTableQuery = @"CREATE TABLE IF NOT EXISTS Inventory (
                                        ID INTEGER PRIMARY KEY,
                                        Name TEXT,
                                        Quantity INTEGER)";
        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    public void AddItem(InventoryItem item)
    {
        string insertQuery = @"INSERT INTO Inventory (Name, Quantity)
                               VALUES (@Name, @Quantity)";
        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);
            command.ExecuteNonQuery();
        }
    }

    public void PrintAllItems()
    {
        string selectQuery = "SELECT * FROM Inventory";
        using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Quantity: {reader["Quantity"]}");
                }
            }
        }
    }

    public void DeleteItem(int id)
    {
        string deleteQuery = "DELETE FROM Inventory WHERE ID = @ID";
        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
        {
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateItemQuantity(int id, int newQuantity)
    {
        string updateQuery = "UPDATE Inventory SET Quantity = @Quantity WHERE ID = @ID";
        using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
        {
            command.Parameters.AddWithValue("@Quantity", newQuantity);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }
    }
}