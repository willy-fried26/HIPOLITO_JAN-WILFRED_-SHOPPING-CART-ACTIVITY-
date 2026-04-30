using System;

public class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
    public string Category;

    public void Display()
    {
        Console.WriteLine($"{Id}. {Name} ({Category}) - ₱{Price} [Stock: {Stock}]");
    }

    public bool HasStock(int qty)
    {
        return qty <= Stock;
    }

    public void Deduct(int qty)
    {
        Stock -= qty;
    }
}
