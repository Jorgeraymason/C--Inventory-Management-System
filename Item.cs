//Item Class abstract class definiton 
public abstract class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public abstract void DisplayInfo();
}

public class InventoryItem : Item
{
    public int Quantity { get; set; }

    public InventoryItem(int id, string name, int quantity)
    {
        ID = id;
        Name = name;
        Quantity = quantity;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Quantity: {Quantity}");
    }
}