using System;
using System.Collections.Generic;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine(Id + ". " + Name + " - ₱" + Price + " (Stock: " + RemainingStock + ")");
    }

    public bool HasEnoughStock(int qty)
    {
        return qty <= RemainingStock;
    }

    public void DeductStock(int qty)
    {
        RemainingStock -= qty;
    }
}

class CartItem
{
    public Product Product;
    public int Quantity;

    public double GetSubtotal()
    {
        return Product.Price * Quantity;
    }
}

class Program
{
    static void Main()
    {
        // Harry Potter themed products
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Elder Wand", Price = 4000, RemainingStock = 3 },
            new Product { Id = 2, Name = "Invisibility Cloak", Price = 3500, RemainingStock = 5 },
            new Product { Id = 3, Name = "Nimbus 2000", Price = 6000, RemainingStock = 2 },
            new Product { Id = 4, Name = "Hogwarts Robe", Price = 1500, RemainingStock = 10 },
            new Product { Id = 5, Name = "Chocolate Frog", Price = 200, RemainingStock = 20 }
        };

        List<CartItem> cart = new List<CartItem>();
        string choice = "Y";

        Console.WriteLine("✨ Welcome to Diagon Alley Shop ✨");

        while (choice == "Y" || choice == "y")
        {
            Console.WriteLine("\n=== MAGIC STORE MENU ===");

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            Console.Write("\nEnter product number: ");
            string input1 = Console.ReadLine();

            int productId;
            if (!int.TryParse(input1, out productId) || productId < 1 || productId > products.Length)
            {
                Console.WriteLine("⚠ Invalid product number.");
                continue;
            }

            Product selected = products[productId - 1];

            if (selected.RemainingStock == 0)
            {
                Console.WriteLine("⚠ This item is out of stock!");
                continue;
            }

            Console.Write("Enter quantity: ");
            string input2 = Console.ReadLine();

            int qty;
            if (!int.TryParse(input2, out qty) || qty <= 0)
            {
                Console.WriteLine("⚠ Invalid quantity.");
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("⚠ Not enough stock available.");
                continue;
            }

            // Check if item already in cart
            CartItem existing = null;

            foreach (var item in cart)
            {
                if (item.Product.Id == selected.Id)
                {
                    existing = item;
                }
            }

            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                cart.Add(new CartItem { Product = selected, Quantity = qty });
            }

            selected.DeductStock(qty);

            Console.WriteLine("✔ Item added to cart!");

            Console.Write("Add more items? (Y/N): ");
            choice = Console.ReadLine();
        }

        // Receipt
        double total = 0;

        Console.WriteLine("\n=== 🧾 RECEIPT ===");

        foreach (var item in cart)
        {
            double subtotal = item.GetSubtotal();
            total += subtotal;
            Console.WriteLine(item.Product.Name + " x" + item.Quantity + " = ₱" + subtotal);
        }

        Console.WriteLine("\nGrand Total: ₱" + total);

        double discount = 0;

        if (total >= 5000)
        {
            discount = total * 0.10;
            Console.WriteLine("✨ Discount (10%): ₱" + discount);
        }

        double finalTotal = total - discount;

        Console.WriteLine("Final Total: ₱" + finalTotal);

        Console.WriteLine("\n=== UPDATED STOCK ===");

        for (int i = 0; i < products.Length; i++)
        {
            products[i].DisplayProduct();
        }

        Console.WriteLine("\nThank you for shopping at Diagon Alley! 🧙‍♂️");
    }
}
