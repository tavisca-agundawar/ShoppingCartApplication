namespace ShoppingCart
{
    public class CartItem
    {
        public Product item { get; private set; }
        public int quantity { get; private set; }
        public double totalCostOfItem { get; private set; }

        public CartItem(Product product, int quantity)
        {
            item = product;
            this.quantity = quantity;

            totalCostOfItem = item.Price * quantity;
        }

    }
}
