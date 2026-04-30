using System;

namespace ShoppingCartSystem
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;
        public string Category;

        public void Display()
        {
            Console.WriteLine($"{Id}. {Name} - ₱{Price} ({Category}) Stock: {Stock}");
        }
    }
}
