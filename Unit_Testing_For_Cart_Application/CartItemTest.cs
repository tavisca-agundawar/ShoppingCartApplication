//using System;
//using FluentAssertions;
//using ShoppingCart;
//using Xunit;


//namespace Unit_Testing_For_Cart_Application
//{
//    public class CartItemTest
//    {
//        [Theory]
//        [InlineData("Coffee", 200,5)]
//        [InlineData("Tea", 150,2)]
//        [InlineData("Water", 20,6)]
//        [InlineData("Pizza", 400,2)]
//        public void test_Cart_Item_Object_Creation(string name, double price, int quantity)
//        {
//            //Arrange
//            Product product = new Product(name, price);
//            CartItem cartItem;

//            //Act
//            cartItem = new CartItem(product, quantity);

//            //Assert
//            cartItem.item.Should().BeEquivalentTo(product);
//            cartItem.quantity.Should().Be(quantity);
//        }
//    }
//}
