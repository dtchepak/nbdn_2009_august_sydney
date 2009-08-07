using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class AddProductToShoppingCart : RawRequestCommand
    {
        ShoppingTasks shopping_tasks;

        public AddProductToShoppingCart(ShoppingTasks shopping_tasks)
        {
            this.shopping_tasks = shopping_tasks;
        }

        public void process(IncomingRequest request)
        {
            shopping_tasks.add_to_shopping_cart(request.map<ItemToAddToCartDetails>());
        }
    }
}