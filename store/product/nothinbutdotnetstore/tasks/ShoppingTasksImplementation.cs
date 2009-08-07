using System;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.orm;

namespace nothinbutdotnetstore.tasks
{
    public class ShoppingTasksImplementation : ShoppingTasks
    {
        Repository repository;
        CartCorral cart_corral;

        public ShoppingTasksImplementation(Repository repository, CartCorral cart_corral)
        {
            this.repository = repository;
            this.cart_corral = cart_corral;
        }

        public void add_to_shopping_cart(ItemToAddToCartDetails details)
        {
            var product_to_add = repository.the_item_matching(ProductQueries.identified_by(details.product_id));
            var cart = cart_corral.get_cart();
            cart.add(product_to_add, details.quantity);
        }
    }
}