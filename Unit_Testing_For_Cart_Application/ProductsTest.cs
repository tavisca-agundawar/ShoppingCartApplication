using System;
using System.Collections.Generic;
using FluentAssertions;
using ShoppingCart;
using Xunit;

namespace Unit_Testing_For_Cart_Application
{
    public class ProductsTest
    {
        [Fact]
        public void test_To_Add_Product_To_List()
        {
            //Arrange
            List<Product> testList;

            //Act
            testList = new List<Product>();

            testList.Add(new Product("a", 100));
            testList.Add(new Product("b", 2500));
            testList.Add(new Product("c", 40));
            testList.Add(new Product("d", 20));

            foreach(var product in testList)
            {
                Products.AddProductToList(product);
            }

            //Assert
            Products.GetProductByName("a").Should().Be(testList[0]);
            Products.GetProductByName("b").Should().Be(testList[1]);
            Products.GetProductByName("c").Should().Be(testList[2]);
            Products.GetProductByName("d").Should().Be(testList[3]);
        }

        [Fact]
        public void test_To_Get_Product_From_List()
        {
            //Arrange
            List<string> names;
            List<Product> products;
            List<Product> testList;
            int i;

            //Act
                        
            testList = new List<Product>();

            testList.Add(new Product("a", 100));
            testList.Add(new Product("b", 2500));
            testList.Add(new Product("c", 40));
            testList.Add(new Product("d", 20));

            foreach (var product in testList)
            {
                Products.AddProductToList(product);
            }

            products = new List<Product>();
            names = new List<string>();
            names.Add("a");
            names.Add("b");
            names.Add("c");
            names.Add("d");

            foreach(var name in names)
            {
                products.Add(Products.GetProductByName(name));
            }

            i = 0;
            //Assert
            foreach (var product in products)
            {
                product.Should().BeEquivalentTo(testList[i]);
                i++;
            }
        }

    }
}
