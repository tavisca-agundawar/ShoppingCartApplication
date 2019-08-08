using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Discount : IDiscount
    {
        public static double discountPercentage = 5;

        public static Dictionary<string, double> CategorialDiscount = new Dictionary<string, double>();

        public static void InitCategorialDiscount()
        {
            var categories = Enum.GetNames(typeof(Product.Categories));
            Random randomValue = new Random();

            for (int index = 0; index < categories.Length; index++)
            {
                CategorialDiscount.Add(categories[index], randomValue.NextDouble()*10);
            }
        }

        public static double GetTotalAmountAfterCartDiscount(double total)
        {
            double netTotal;
            if (total == 0)
            {
                return 0;
            }
            else
            {
                netTotal = total - (total * discountPercentage / 100);
            }
            return netTotal;
        }

        public static double GetTotalAmountAfterCategorialDiscount(List<CartItem> cartItems)
        {
            double discount;
            double netTotal = 0;
            foreach(var product in cartItems)
            {
                discount = 0;
                CategorialDiscount.TryGetValue(product.item.Category.ToString(), out discount);
                if(discount>0)
                {
                    netTotal += product.totalCostOfItem - (product.totalCostOfItem * discount / 100);
                }
                else
                {
                    netTotal += product.totalCostOfItem;
                }
            }
            return netTotal;
        }
    }
}
