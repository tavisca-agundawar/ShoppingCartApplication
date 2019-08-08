using System;
using FluentAssertions;
using ShoppingCart;
using Xunit;

namespace Unit_Testing_For_Cart_Application
{
    public class ProductTest
    {
        [Theory]
        [InlineData("Coffee", 200)]
        [InlineData("Tea", 150)]
        [InlineData("Water", 20)]
        [InlineData("Pizza", 400)]
        public void test_To_Set_Product_Properties(string name, double price)
        {
            //Arrange
            Product product;

            //Act
            product = new Product(name, price);

            //Assert
            product.Name.Should().Be(name);
            product.Price.Should().Be(price);
        }
    }
}
