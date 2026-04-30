using System;

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
        Product[] products =
        {
            new Product { Id = 1, Name = "Elder Wand", Price = 4000, RemainingStock = 3 },
            new Product { Id = 2, Name = "Invisibility Cloak", Price = 3500, RemainingStock = 5 },
            new Product { Id = 3, Name = "Nimbus 2000", Price = 6000, RemainingStock = 2 },
            new Product { Id = 4, Name = "Hogwarts Robe", Price = 1500, RemainingStock = 10 },
            new Product { Id = 5, Name = "Chocolate Frog", Price = 200, RemainingStock = 20 }
        };

        //  FIX: Use fixed-size cart array
        CartItem[] cart = new CartItem[10];
        int cartCount = 0;

        string choice = "Y";

        Console.WriteLine("✨ Welcome to Diagon Alley Shop ✨");

        while (choice == "Y" || choice == "y")
        {
            Console.WriteLine("\n=== MAGIC STORE MENU ===");

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            //  FIX: Cart full check
            if (cartCount >= cart.Length)
            {
                Console.WriteLine("⚠ Cart is full!");
                break;
            }

            Console.Write("\nEnter product number: ");
            int productId;

            if (!int.TryParse(Console.ReadLine(), out productId) || productId < 1 || productId > products.Length)
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
            int qty;

            if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.WriteLine("⚠ Invalid quantity.");
                continue;
            }

            if (!selected.HasEnoughStock(qty))
            {
                Console.WriteLine("⚠ Not enough stock available.");
                continue;
            }

            //  CHECK EXISTING ITEM
            int index = -1;

            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i].Product.Id == selected.Id)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                cart[index].Quantity += qty;
            }
            else
            {
                cart[cartCount] = new CartItem { Product = selected, Quantity = qty };
                cartCount++;
            }

            selected.DeductStock(qty);

            Console.WriteLine("✔ Item added to cart!");

            Console.Write("Add more items? (Y/N): ");
            choice = Console.ReadLine();
        }

        // RECEIPT
        double total = 0;

        Console.WriteLine("\n=== 🧾 RECEIPT ===");

        for (int i = 0; i < cartCount; i++)
        {
            double subtotal = cart[i].GetSubtotal();
            total += subtotal;

            Console.WriteLine(cart[i].Product.Name + " x" + cart[i].Quantity + " = ₱" + subtotal);
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
