using developwithpassion.bdd;
using nothinbutdotnetstore.infrastructure;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.ui;
using System.Windows.Forms;

namespace nothinbutdotnetstore.tests.ui
{
    public class ButtonBinderSpec
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<ButtonBinder>
        {

        }

        [Concern(typeof(ButtonBinder))]
        public class when_button_is_clicked : concern
        {
            context c = () =>
            {
                button = new Button();
                provide_a_basic_sut_constructor_argument(button);
                command = the_dependency<Command>();
            };

            because b = () =>
            {
                button.PerformClick();
            };

            it should_run_command = () =>
            {
                command.received(x => x.run());
            };

            static Button button;
            static Command command;
        }
    }
}