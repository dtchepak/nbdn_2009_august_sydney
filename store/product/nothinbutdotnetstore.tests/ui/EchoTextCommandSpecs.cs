 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.ui;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.ui
 {   
     public class EchoTextCommandSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Command, EchoTextCommand>
         {
        
         }

         [Concern(typeof(EchoTextCommand))]
         public class when_told_to_run : concern
         {
             it should_read_text_and_write_it_back = () =>
             {
                result.should_be_equal_to(text_to_be_read);
            
             };

             because b = () =>
             {
                 sut.run();
             };


             context c = () =>
             {
                 Func<string> read_text = () => text_to_be_read;
                 Action<string> write_text = (text) => result = text;
                 provide_a_basic_sut_constructor_argument(read_text);
                 provide_a_basic_sut_constructor_argument(write_text);
             };

             static string result;
             static string text_to_be_read;
         }
     }
 }
