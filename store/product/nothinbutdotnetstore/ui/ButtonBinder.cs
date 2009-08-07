using System.Windows.Forms;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.ui
{
    public class ButtonBinder
    {
        public ButtonBinder(Button button, Command command)
        {
            button.Click += (sender, args) => command.run();
        }
    }
}