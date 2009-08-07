using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.domain
{
    public class ShoppingCartSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCart>
        {
            static protected IList<CartItem> cart_items;

            context c = () =>
            {
                cart_items = new List<CartItem>();
                cart_item_factory = the_dependency<CartItemFactory>();
                provide_a_basic_sut_constructor_argument(cart_items);
            };

            static protected CartItemFactory cart_item_factory;
        }


        [Concern(typeof (ShoppingCart))]
        public class when_a_shopper_adds_a_product : concern
        {
            context c = () =>
            {
                product = an<Product>();
                cart_item = an<CartItem>();
                cart_item_factory.Stub(x => x.create_item_for(product, 123)).Return(cart_item);
            };

            because b = () =>
            {
                sut.add(product, 123);
            };

            it should_add_the_product_to_the_shopping_cart = () =>
            {
                cart_items.should_only_contain(cart_item);
            };

            static Product product;
            static CartItem cart_item;
        }

        public class a_shopping_cart_with_one_item_in_it : concern
        {
            context c = () =>
            {
                product_that_is_already_in_the_cart = an<Product>();
                cart_item = an<CartItem>();

                cart_items.Add(cart_item);
                cart_item.Stub(x => x.is_item_for(product_that_is_already_in_the_cart)).Return(true);
            };


            static protected Product product_that_is_already_in_the_cart;
            static protected CartItem cart_item;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_a_shopper_adds_a_product_that_is_already_in_the_shopping_cart : a_shopping_cart_with_one_item_in_it
        {
            because b = () =>
            {
                sut.add(product_that_is_already_in_the_cart, 5);
            };

            it should_increment_the_quantity_of_the_item = () =>
            {
                cart_item.received(x => x.increment_quantity_by(5));
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_a_shopper_removes_an_product_from_the_shopping_cart : a_shopping_cart_with_one_item_in_it
        {
            because b = () =>
            {
                sut.remove(product_that_is_already_in_the_cart);
            };

            it should_remove_the_item_for_the_product = () =>
            {
                cart_items.Count.should_be_equal_to(0);
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_removing_an_item_that_is_not_in_the_shopping_cart : a_shopping_cart_with_one_item_in_it
        {
            context c = () =>
            {
                product = an<Product>();
            };

            because b = () =>
            {
                sut.remove(product);
            };

            it should_be_ignored = () =>
            {
                cart_items.Count.should_be_equal_to(1);
            };

            static Product product;
        }


        [Concern(typeof (ShoppingCart))]
        public class when_a_shopper_modifies_the_quantity_of_a_product_in_the_shopping_shopping_cart : a_shopping_cart_with_one_item_in_it
        {
            because b = () =>
            {
                sut.change_quantity(product_that_is_already_in_the_cart, 5);
            };

            it should_change_the_quantity_of_a_product = () =>
            {
                cart_item.received(x => x.change_quantity_to(5));
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_attempting_to_change_the_quantity_of_an_product_not_in_the_shopping_cart : a_shopping_cart_with_one_item_in_it
        {
            context c = () =>
            {
                product_not_in_the_cart = an<Product>();
            };
            because b = () =>
            {
                sut.change_quantity(product_not_in_the_cart, 5);
            };

            it should_not_do_anything = () =>
            {
            };

            static Product product_not_in_the_cart;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_changing_the_quantity_causes_the_item_for_product_to_be_empty : a_shopping_cart_with_one_item_in_it
        {
            context c = () =>
            {
                cart_item.Stub(x => x.is_empty()).Return(true);
            };

            because b = () =>
            {
                sut.change_quantity(product_that_is_already_in_the_cart, 0);
            };

            it should_remove_the_item_from_the_shopping_cart = () =>
            {
                cart_items.Count.should_be_equal_to(0);
            };
        }

        public abstract class a_shopping_cart_with_10_items_in_it : concern
        {
            context c = () =>
            {
                Enumerable.Range(1, 10).each(item =>
                {
                    cart_items.Add(an<CartItem>());
                });
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_calculating_the_total_cost_of_the_cart : a_shopping_cart_with_10_items_in_it
        {
            context c = () =>
            {
                cart_items.each(item =>
                {
                    item.Stub(x => x.calculate_total_cost()).Return(10m);
                });
                var high_price_item = an<CartItem>();
                high_price_item.Stub(x => x.calculate_total_cost()).Return(13.50m);
                cart_items.Add(high_price_item);
            };

            because b = () =>
            {
                result = sut.calculate_total_cost();
            };

            it should_return_the_sum_of_the_cost_of_the_items = () =>
            {
                result.should_be_equal_to(113.50m);
            };

            static decimal result;
        }
    }
}