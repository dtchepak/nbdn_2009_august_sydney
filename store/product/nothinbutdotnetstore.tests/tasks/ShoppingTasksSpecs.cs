using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.orm;
using nothinbutdotnetstore.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
{
    public class ShoppingTasksSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ShoppingTasks,
                                            ShoppingTasksImplementation> {}

        [Concern(typeof (ShoppingTasksImplementation))]
        public class when_adding_a_product_to_the_shopping_cart : concern
        {
            context c = () =>
            {
                shopping_cart = an<ShoppingCart>();
                repository = the_dependency<Repository>();
                cart_corral = the_dependency<CartCorral>();
                product_to_be_added = an<Product>();

                details = new ItemToAddToCartDetails
                          {
                              product_id = new Id<long>(),
                              quantity = 2
                          };

                repository.Stub(x => x.the_item_matching(ProductQueries.identified_by(details.product_id))).Return(product_to_be_added);
                cart_corral.Stub(x => x.get_cart()).Return(shopping_cart);
            };

            because b = () =>
            {
                sut.add_to_shopping_cart(details);
            };


            it should_add_the_product_to_the_shopping_cart = () =>
            {
                shopping_cart.received(x => x.add(product_to_be_added, details.quantity));
            };

            static Repository repository;
            static ShoppingCart shopping_cart;
            static Product product_to_be_added;
            static ItemToAddToCartDetails details;
            static CartCorral cart_corral;
        }
    }
}