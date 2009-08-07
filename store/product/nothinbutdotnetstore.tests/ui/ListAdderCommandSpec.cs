using System;
using System.Collections.Generic;
using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using MbUnit.Framework;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.ui;
using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.ui
{
    public class ListAdderCommandSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                            ListAdderCommand>
        {

        }

        [Concern(typeof(ListAdderCommand))]
        public class when_told_to_run : concern
        {
            it should_add_the_text_returned_by_its_reader_to_its_list_view = () =>
            {
                foreach (ListViewItem item in list_view.Items)
                {
                    if (item.Text == text_to_add)
                    {
                        true.should_be_true();
                    }
                }
            };

            because b = () =>
            {
                sut.run();
            };

            context c = () =>
            {
                text_to_add = "howdy";
                list_view = new ListView();
                Func<string> text_reader = () => text_to_add;
                provide_a_basic_sut_constructor_argument(list_view);
                provide_a_basic_sut_constructor_argument(text_reader);
            };

            static ListView list_view;
            static string text_to_add;
        }
    }
}
