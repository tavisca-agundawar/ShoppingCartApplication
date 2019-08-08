﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Products
    {
        private static List<Product> _list = new List<Product>();

        public static List<Product> GetProductList()
        {
            return _list;
        }

        public static void AddProductToList(Product product)
        {
            _list.Add(product);
        }
        public static void RemoveProductFromList(Product product)
        {
            if(_list.Remove(_list.Find(x => x.Name == product.Name)))
            {
                Display.ShowMessage("Product Removed!");
            }
            else
            {
                Display.ShowMessage("Error! Product not found!");
            }
        }

        public static Product GetProductByName(string productName)
        {
            if (_list.Count > 0)
            {

                return _list.Find(x => x.Name == productName);
                //foreach (var product in _list)
                //{
                //    if (product.Name.Equals(productName))
                //    {
                //        return product;
                //    }
                //}
            }
            else
            {
                Display.ShowMessage("Product not found!");   
            }
            return null;
        }

        public static void ShowProductDetail(string productName)
        {
            var product = GetProductByName(productName);
            if(product != null)
            {
                Display.ShowMessage($"Product Name: {product.Name}");
                Display.ShowMessage($"Product Price: {product.Price}");
                Display.ShowMessage($"Product Category: {product.Category}");
            }
            else
            {
                Display.ShowMessage("Product not found!");
            }
        }

        public static void ShowAllProducts()
        {
            if (_list.Count > 0)
            {
                Display.ShowMessage(Environment.NewLine);
                Display.ShowMessage("Product Name       Price/Unit      Category");
                foreach (var product in _list)
                {
                    Display.ShowMessage($"{product.Name}                {product.Price}         {product.Category}");
                }
                Display.ShowMessage(Environment.NewLine);
            }
            else
            {
                Display.ShowMessage("No products added!");
            }
        }
    }
}
