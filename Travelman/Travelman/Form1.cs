using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Travelman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Controls.Add(new Button());
            Controls.Add(new LocationSelection("Destination", FontAwesomeFont.fa.flag_o, 2));
        }
    }
}
