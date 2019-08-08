using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLauncher
{
    class Launcher
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Cart cart = new Cart();
            
            while(!exit)
            {
                ShowMainMenu();
                var choice = Convert.ToInt32(Display.GetInputFromUser("Enter choice:"));
                switch (choice)
                {
                    case 1:
                        bool exitVendorMenu = false;
                        while(!exitVendorMenu)
                        {
                            int vendorChoice = 0;
                            ShowVendorMenu();
                            try
                            {
                                vendorChoice = Convert.ToInt32(Display.GetInputFromUser("Enter choice:"));
                            }
                            catch (Exception)
                            {
                            }
                            
                            switch (vendorChoice)
                            {
                                case 1:
                                    Vendor.AddProduct();
                                    break;
                                case 2:
                                    Vendor.RemoveProduct();
                                    break;

                                case 3:
                                    Vendor.SetCartWideDiscount();
                                    Display.ShowMessage("Discount Set!");
                                    break;

                                case 4:
                                    Vendor.SetCategoryDiscount();
                                    Display.ShowMessage("Discount Set!");
                                    break;

                                case 5:
                                    Discount.ShowCategorialDiscountValues();
                                    break;
                                case 6:
                                    Products.ShowAllProducts();
                                    break;

                                case 7:
                                    exitVendorMenu = true;
                                    break;

                                default:
                                    Display.ShowMessage("Invalid input! Please try again.");
                                    break;
                            }
                        }
                        break;


                    case 2:
                        bool exitShopperMenu = false;
                        while (!exitShopperMenu)
                        {
                            int shopperChoice = 0;
                            ShowShopperMenu();
                            try
                            {
                                shopperChoice = Convert.ToInt32(Display.GetInputFromUser("Enter choice:"));
                            }
                            catch (Exception)
                            { 

                            }
                            
                            switch (shopperChoice)
                            {
                                case 1:
                                    Products.ShowAllProducts();
                                    break;

                                case 2:
                                    Products.ShowProductDetail(Display.GetInputFromUser("Enter product name:"));
                                    break;

                                case 3:
                                    cart.AddToCart();
                                    break;

                                case 4:
                                    cart.RemoveFromCart();
                                    break;

                                case 5:
                                    Discount.ShowCategorialDiscountValues();
                                    break;

                                case 6:
                                    cart.Checkout();
                                    break;

                                case 7:
                                    exitShopperMenu = true;
                                    break;

                                default:
                                    Display.ShowMessage("Invalid input! Please try again.");
                                    break;
                            }
                        }
                        break;

                    case 3:
                        exit = true;
                        break;

                    default:
                        Display.ShowMessage("Invalid input! Please try again.");
                        break;
                }
            }
        }

        public static void ShowMainMenu()
        {
            Display.ShowMessage(Environment.NewLine);
            Display.ShowMessagePretty("\t\t Main Menu");
            Display.ShowMessage("Choose an option from the following:");
            Display.ShowMessage("1.Vendor Menu");
            Display.ShowMessage("2.Shopper Menu");
            Display.ShowMessage("3.Exit");
        }

        public static void ShowVendorMenu()
        {
            Display.ShowMessage(Environment.NewLine);
            Display.ShowMessagePretty("\t\t Vendor Menu");
            Display.ShowMessage("Choose an option from the following:");
            Display.ShowMessage("1.Add product");
            Display.ShowMessage("2.Remove product");
            Display.ShowMessage("3.Set fixed discount");
            Display.ShowMessage("4.Set Category Discount");
            Display.ShowMessage("5.Show discount per category");
            Display.ShowMessage("6.Show list of products");
            Display.ShowMessage("7.Return to Main Menu");
        }

        public static void ShowShopperMenu()
        {
            Display.ShowMessage(Environment.NewLine);
            Display.ShowMessagePretty("\t\t Shopper Menu");
            Display.ShowMessage("Choose an option from the following:");
            Display.ShowMessage("1.View all products");
            Display.ShowMessage("2.Search product by name");
            Display.ShowMessage("3.Add product to cart");
            Display.ShowMessage("4.Remove product from cart");
            Display.ShowMessage("5.Show discount per category");
            Display.ShowMessage("6.Checkout");
            Display.ShowMessage("7.Return to Main Menu");
        }
    }
}
