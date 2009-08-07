using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ShoppingTasks
    {
        void add_to_shopping_cart(ItemToAddToCartDetails details);
    }
}