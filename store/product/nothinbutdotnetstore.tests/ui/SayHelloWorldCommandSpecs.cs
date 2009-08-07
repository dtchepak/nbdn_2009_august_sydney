using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.ui;
using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.ui
{
    public class SayHelloWorldCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                            nothinbutdotnetstore.ui.SayHelloWorldCommand>
        {

        }

        [Concern(typeof(nothinbutdotnetstore.ui.SayHelloWorldCommand))]
        public class when_told_to_run : concern
        {
            it should_say_hello_world_via_the_passed_in_function = () =>
            {
                result.should_be_equal_to("Hello World!");
            };

            because b = () =>
            {
                sut.run();
            };

            context c = () =>
            {
                Action<string> writer_function = (say_to_this) => result = say_to_this;
                provide_a_basic_sut_constructor_argument(writer_function);
            };

            static string result;
        }
    }
}
