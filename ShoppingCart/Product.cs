
using System;

namespace ShoppingCart
{
    public partial class Product : IItem
    {
        public string Name { get; private set; }

        public double Price { get; private set; }

        public Categories Category; 
        public Product(string name, double price, string category)
        {
            this.Name = name;
            this.Price = price;
            Enum.TryParse(category, out this.Category);
        }


    }
}
