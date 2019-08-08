namespace ShoppingCart
{
    public class CartItem
    {
        public Product Item { get; private set; }
        public int Quantity { get; private set; }
        public double TotalCostOfItem { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Item = product;
            this.Quantity = quantity;

            TotalCostOfItem = Item.Price * quantity;
        }

    }
}
