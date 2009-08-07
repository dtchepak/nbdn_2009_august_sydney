using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCart
    {
        IList<CartItem> items;
        CartItemFactory cart_item_factory;

        protected ShoppingCart() {}

        public ShoppingCart(IList<CartItem> items, CartItemFactory cart_item_factory)
        {
            this.items = items;
            this.cart_item_factory = cart_item_factory;
        }


        public virtual void add(Product product, int quantity)
        {
            if (contains_item_for(product))
            {
                get_item_for(product).increment_quantity_by(quantity);
                return;
            }
            items.Add(cart_item_factory.create_item_for(product, quantity));
        }

        CartItem get_item_for(Product product)
        {
            return items.FirstOrDefault(item => item.is_item_for(product)) ?? new MissingCartItem();
        }

        bool contains_item_for(Product product)
        {
            return items.Any(item => item.is_item_for(product));
        }

        public void remove(Product product)
        {
            items.Remove(get_item_for(product));
        }

        public void change_quantity(Product product, int new_quantity)
        {
            var item = get_item_for(product);
            item.change_quantity_to(new_quantity);
            if (item.is_empty()) items.Remove(item);
        }

        public virtual decimal calculate_total_cost()
        {
            return items.Sum(item => item.calculate_total_cost());
        }
    }

    class MissingCartItem : CartItem
    {
        public override bool is_item_for(Product product)
        {
            return false;
        }

        public override void increment_quantity_by(int number) {}
        public override void change_quantity_to(int new_quantity) {}

        public override bool is_empty()
        {
            return true;
        }

        public override decimal calculate_total_cost()
        {
            return 0m;
        }
    }
}