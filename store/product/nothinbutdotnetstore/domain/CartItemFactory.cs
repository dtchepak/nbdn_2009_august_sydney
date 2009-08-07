namespace nothinbutdotnetstore.domain
{
    public interface CartItemFactory
    {
        CartItem create_item_for(Product product, int quantity);
    }
}