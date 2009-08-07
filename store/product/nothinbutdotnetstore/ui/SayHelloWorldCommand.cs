using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.ui
{
    public class SayHelloWorldCommand : Command
    {
        readonly Action<string> say_hello_via_the_little_friend;
        public SayHelloWorldCommand(Action<string> say_hello_to_this)
        {
            say_hello_via_the_little_friend = say_hello_to_this;
        }

        public void run()
        {
            say_hello_via_the_little_friend("Hello World!");
        }
    }
}