using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Cart
    {
        //public static double discountPercentage = 5;

        public List<CartItem> cartItems = new List<CartItem>();
        private double _baseCartValue;
        private double _cartDiscountedValue;
        private double _categorialDiscountedValue;

        public Cart()
        {
            Discount.InitCategorialDiscount();
        }
        public void AddToCart()
        {
            try
            {
                var product = Products.GetProductByName(Display.GetInputFromUser("Enter product name:"));
                var quantity = Convert.ToInt32(Display.GetInputFromUser("Enter quantity required:"));
                if (quantity <= 0)
                    throw new Exception();

                cartItems.Add(new CartItem(product, quantity));
                Display.ShowMessage($"{cartItems[cartItems.Count - 1].Quantity} x {cartItems[cartItems.Count - 1].Item.Name} added to cart!");
            }
            catch (Exception)
            {
                Display.ShowMessage("Invalid product/quantity entered!");
            }

        }

        public void RemoveFromCart()
        {
            try
            {
                ShowCartItems();
                var product = Display.GetInputFromUserPretty("Enter product name to remove:");

                for (int i = 0; i < cartItems.Count; i++)
                {
                    if(cartItems[i].Item.Name == product)
                    {
                        cartItems.RemoveAt(i);
                        Display.ShowMessage($"{product} has been removed.");
                    }
                }
                
            }
            catch (Exception)
            {
                Display.ShowMessage("Invalid product/quantity entered!");
            }

        }

        public void Checkout()
        {
            _baseCartValue = GetTotalAmount();
            _cartDiscountedValue = Discount.GetTotalAmountAfterCartDiscount(_baseCartValue);
            _categorialDiscountedValue = Discount.GetTotalAmountAfterCategorialDiscount(cartItems);

            ShowCartValue();
            Display.ShowMessagePretty("1.Fixed Discount \n2.Categorial Discount");
            var choice = Display.GetInputFromUserPretty("Enter choice of discount to apply:");
            switch (choice)
            {
                case "1":
                    Display.ShowMessagePretty($"GRAND TOTAL: {_cartDiscountedValue}");
                    break;
                case "2":
                    Display.ShowMessagePretty($"GRAND TOTAL: {_categorialDiscountedValue}");
                    break;
                default:
                    Display.ShowMessagePretty("Error! Invalid input.");
                    break;
            }
        }

        public double GetTotalAmount()
        {
            if (cartItems.Count > 0)
            {
                double total = 0;
                foreach (var cartItem in cartItems)
                {
                    total += cartItem.TotalCostOfItem;
                }
                return total;
            }
            else
            {
                Display.ShowMessage("Error! Cart empty!");
            }
            return 0;
        }


        public void ShowCartValue()
        {
            ShowCartItems();
            Display.ShowMessage("--------------------------------------------------------------------");
            Display.ShowMessage($"Total Amount: {_baseCartValue}");
            Display.ShowMessage($"Cart Discount: {Discount.discountPercentage}%  =  {_baseCartValue * Discount.discountPercentage / 100}");
            Display.ShowMessage($"Cart Total after Fixed Discount: {_cartDiscountedValue}");
            Display.ShowMessage($"Cart Total after Categorial Discount: {_categorialDiscountedValue}");
            Display.ShowMessage("--------------------------------------------------------------------");
        }

        public void ShowCartItems()
        {
            Display.ShowMessage(" Product Name       Product Price/Unit       Quantity        Total");
            Display.ShowMessage("--------------------------------------------------------------------");
            foreach (var cartItem in cartItems)
            {
                Display.ShowMessage($"{cartItem.Item.Name}            {cartItem.Item.Price}           {cartItem.Quantity}            {cartItem.TotalCostOfItem}");
            }
        }
    }
}
