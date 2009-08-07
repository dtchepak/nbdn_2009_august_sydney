using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.ui
{
    public class EchoTextCommand : Command
    {
        readonly Func<string> read_text;
        readonly Action<string> write_text;

        public EchoTextCommand(Func<string> read_text, Action<string> write_text)
        {
            this.read_text = read_text;
            this.write_text = write_text;
        }

        public void run()
        {
            write_text(read_text());
        }
    }
}