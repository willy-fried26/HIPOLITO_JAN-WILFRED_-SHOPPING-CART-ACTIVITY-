using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
    public string Category;
}

class CartItem
{
    public Product Product;
    public int Quantity;

    public double Subtotal()
    {
        return Product.Price * Quantity;
    }
}

class Program
{
    static Product[] products =
    {
        new Product { Id=1, Name="Rice", Price=60, Stock=20, Category="Food" },
        new Product { Id=2, Name="Tuna", Price=35, Stock=15, Category="Food" },
        new Product { Id=3, Name="Shampoo", Price=120, Stock=10, Category="Care" },
        new Product { Id=4, Name="Toothpaste", Price=85, Stock=12, Category="Care" },
        new Product { Id=5, Name="Soda", Price=50, Stock=25, Category="Drink" }
    };

    static CartItem[] cart = new CartItem[10];
    static int cartCount = 0;

    static string[] history = new string[50];
    static int historyCount = 0;

    static int receiptNo = 1;

    static void Main()
    {
        string choice = "y";

        Console.WriteLine("Barangay Mini Mart");

        while (choice == "y" || choice == "Y")
        {
            Console.WriteLine("\n1. Show Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.Write("Choice: ");
            string opt = Console.ReadLine();

            if (opt == "1") ShowProducts();
            else if (opt == "2") SearchProduct();
            else if (opt == "3") FilterCategory();

            if (cartCount >= cart.Length)
            {
                Console.WriteLine("Cart is full.");
                break;
            }

            Console.Write("\nEnter product #: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > products.Length)
            {
                Console.WriteLine("Invalid.");
                continue;
            }

            Product selected = products[id - 1];

            Console.Write("Qty: ");
            int qty;
            if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.WriteLine("Invalid.");
                continue;
            }

            if (qty > selected.Stock)
            {
                Console.WriteLine("Not enough stock.");
                continue;
            }

            AddToCart(selected, qty);
            selected.Stock -= qty;

            CartMenu();

            choice = AskYN("\nContinue shopping? (Y/N): ");
        }

        Console.WriteLine("Thank you!");
    }


    static void ShowProducts()
    {
        Console.WriteLine("\n=== PRODUCTS ===");
        foreach (var p in products)
            Console.WriteLine($"{p.Id}. {p.Name} ₱{p.Price} ({p.Category}) Stock:{p.Stock}");
    }

    static void SearchProduct()
    {
        Console.Write("Search name: ");
        string search = Console.ReadLine().ToLower();

        foreach (var p in products)
        {
            if (p.Name.ToLower().Contains(search))
                Console.WriteLine($"{p.Id}. {p.Name} ₱{p.Price} Stock:{p.Stock}");
        }
    }

    static void FilterCategory()
    {
        Console.WriteLine("\nCategories:");
        Console.WriteLine("1. Food\n2. Care\n3. Drink");

        Console.Write("Choose: ");
        string cat = Console.ReadLine();

        string selectedCat = "";

        if (cat == "1") selectedCat = "Food";
        else if (cat == "2") selectedCat = "Care";
        else if (cat == "3") selectedCat = "Drink";

        foreach (var p in products)
        {
            if (p.Category == selectedCat)
                Console.WriteLine($"{p.Id}. {p.Name} ₱{p.Price} Stock:{p.Stock}");
        }
    }

    static void AddToCart(Product p, int qty)
    {
        for (int i = 0; i < cartCount; i++)
        {
            if (cart[i].Product.Id == p.Id)
            {
                cart[i].Quantity += qty;
                return;
            }
        }

        cart[cartCount] = new CartItem { Product = p, Quantity = qty };
        cartCount++;
    }

    static void CartMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== CART MENU ===");
            Console.WriteLine("1. View Cart\n2. Remove\n3. Update\n4. Clear\n5. Checkout");

            Console.Write("Choice: ");
            int c;
            if (!int.TryParse(Console.ReadLine(), out c)) continue;

            if (c == 1) ViewCart();
            else if (c == 2) RemoveItem();
            else if (c == 3) UpdateItem();
            else if (c == 4) { cartCount = 0; Console.WriteLine("Cart cleared."); }
            else if (c == 5) { Checkout(); break; }
        }
    }

    static void ViewCart()
    {
        for (int i = 0; i < cartCount; i++)
            Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity}");
    }

    static void RemoveItem()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < cartCount; i++)
        {
            if (cart[i].Product.Id == id)
            {
                for (int j = i; j < cartCount - 1; j++)
                    cart[j] = cart[j + 1];

                cartCount--;
                Console.WriteLine("Removed.");
                return;
            }
        }
    }

    static void UpdateItem()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Qty: ");
        int q = int.Parse(Console.ReadLine());

        for (int i = 0; i < cartCount; i++)
        {
            if (cart[i].Product.Id == id)
            {
                cart[i].Quantity = q;
                Console.WriteLine("Updated.");
                return;
            }
        }
    }

    static void Checkout()
    {
        double total = 0;

        for (int i = 0; i < cartCount; i++)
            total += cart[i].Subtotal();

        double discount = total >= 1000 ? total * 0.05 : 0;
        double finalTotal = total - discount;

        double payment;

        while (true)
        {
            Console.WriteLine($"Final: ₱{finalTotal}");
            Console.Write("Payment: ");
            if (double.TryParse(Console.ReadLine(), out payment) && payment >= finalTotal)
                break;

            Console.WriteLine("Invalid payment.");
        }

        double change = payment - finalTotal;

        Console.WriteLine("\n=== RECEIPT ===");
        Console.WriteLine($"Receipt #: {receiptNo:0000}");
        Console.WriteLine("Date: " + DateTime.Now);

        for (int i = 0; i < cartCount; i++)
            Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity}");

        Console.WriteLine($"Total: ₱{total}");
        Console.WriteLine($"Discount: ₱{discount}");
        Console.WriteLine($"Final: ₱{finalTotal}");
        Console.WriteLine($"Payment: ₱{payment}");
        Console.WriteLine($"Change: ₱{change}");

        history[historyCount++] = $"Receipt #{receiptNo:0000} - ₱{finalTotal}";
        receiptNo++;

        LowStock();
        ShowHistory();

        cartCount = 0;
    }

    static void LowStock()
    {
        Console.WriteLine("\nLOW STOCK:");
        foreach (var p in products)
        {
            if (p.Stock <= 5)
                Console.WriteLine($"{p.Name} only {p.Stock} left.");
        }
    }

    static void ShowHistory()
    {
        Console.WriteLine("\nORDER HISTORY:");
        for (int i = 0; i < historyCount; i++)
            Console.WriteLine(history[i]);
    }

    static string AskYN(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine();

            if (input == "Y" || input == "y" || input == "N" || input == "n")
                return input;

            Console.WriteLine("Invalid. Enter Y or N only.");
        }
    }
}
