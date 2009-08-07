using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class AddProductToShoppingCartSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            AddProductToShoppingCart> {}

        [Concern(typeof (AddProductToShoppingCart))]
        public class when_adding_a_product_to_the_shopping_cart : concern
        {
            it should_send_the_details_of_the_product_to_add_to_the_service_layer = () =>
            {
                shopping_tasks.received(x => x.add_to_shopping_cart(item_to_add_to_cart_details));
            };

            because b = () =>
            {
                sut.process(request);
            };

            context c = () =>
            {
                request = an<IncomingRequest>();
                item_to_add_to_cart_details = new ItemToAddToCartDetails();
                shopping_tasks = the_dependency<ShoppingTasks>();

                request.Stub(x => x.map<ItemToAddToCartDetails>()).Return(item_to_add_to_cart_details);
            };


            static ShoppingTasks shopping_tasks;
            static ItemToAddToCartDetails item_to_add_to_cart_details;
            static IncomingRequest request;
        }
    }
}