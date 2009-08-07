using System;
using System.Windows.Forms;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.ui
{
    public class ListAdderCommand : Command
    {
        ListView list_view;
        Func<string> reader;
        public ListAdderCommand(ListView list_view, Func<string> reader)
        {
            this.list_view = list_view;
            this.reader = reader;
        }

        public void run()
        {
            list_view.Items.Add(new ListViewItem(reader()));
        }
    }
}