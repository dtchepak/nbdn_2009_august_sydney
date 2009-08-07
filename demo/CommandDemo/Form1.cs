using System.Windows.Forms;
using nothinbutdotnetstore.ui;

namespace CommandDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new ButtonBinder(button1, new SayHelloWorldCommand(s => label1.Text = s));
            new ButtonBinder(button2, new EchoTextCommand(() => textBox1.Text, s => label2.Text = s));
            new ButtonBinder(button3, new ListAdderCommand(listView1, () => textBox1.Text));
        }
    }
}
