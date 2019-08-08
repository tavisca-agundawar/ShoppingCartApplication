using FluentAssertions;
using Xunit;
using ShoppingCart;

namespace Unit_Testing_For_Cart_Application
{
    public class DisplayTest
    {
        [Theory]
        [InlineData("Hello","Hello")]
        [InlineData("World", "World")]
        [InlineData("Arnaw", "Arnaw")]
        public void Test_Get_Input_From_User_Pretty(string input, string expectedOutput)
        {
            var output = Display.GetInputFromUserPretty(input);

            output.Should().Be(expectedOutput);
        }
    }
}
