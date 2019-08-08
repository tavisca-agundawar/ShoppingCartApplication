using System;

namespace ShoppingCart
{
    public class Vendor
    {
        public static void AddProduct()
        {
            string name = Display.GetInputFromUser("Enter Product Name:");
            double price = Convert.ToDouble(Display.GetInputFromUser("Enter product price:"));
            string category = GetCategoryFromUser();

            Products.AddProductToList(new Product(name,price,category));
        }

        private static string GetCategoryFromUser()
        {
            var categories = Enum.GetNames(typeof(Product.Categories));

            Display.ShowMessagePretty("Categories:");
            for(int index = 0; index < categories.Length; index++)
            {
                Display.ShowMessage($"{index+1}: {categories[index]}");
            }
            return Convert.ToString((Convert.ToInt32(Display.GetInputFromUserPretty("Enter Category Index: ")) - 1));
        }

        public static void SetCategoryDiscount()
        {
            var categories = Enum.GetNames(typeof(Product.Categories));
            var chosenCategory = GetCategoryFromUser();
            string chosenCategoryName = Enum.GetName(typeof(Product.Categories), Convert.ToInt32(chosenCategory));

            double discount = Convert.ToDouble(Display.GetInputFromUserPretty($"Enter discount percent for {chosenCategoryName}: "));

            if (Discount.CategorialDiscount.ContainsKey(chosenCategoryName))
            {
                Discount.CategorialDiscount.Remove(chosenCategoryName);
                Discount.CategorialDiscount.Add(chosenCategoryName, discount);
            }
            else
            {
                Discount.CategorialDiscount.Add(chosenCategoryName, discount);
            }

        }

        public static void SetCartWideDiscount()
        {
            Discount.discountPercentage = Convert.ToDouble(Display.GetInputFromUser("Set discount percentage:"));
        }
    }
}
