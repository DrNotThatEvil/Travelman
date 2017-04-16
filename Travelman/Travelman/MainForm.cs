using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Travelman
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            // Initialize MaterialSkinManager
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.AddFormToManage(this);
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();
            StartView sv = new StartView() { Dock = DockStyle.Fill };
            formContent.Controls.Add(sv);
            //Controls.Add(new LocationSelection("Destination", FontAwesome.Sharp.IconChar.FlagO, 2));
        }

        private void dummyPanel_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void dummyPanel_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void dummyPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void formContent_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void formContent_MouseLeave(object sender, System.EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void formContent_MouseHover(object sender, System.EventArgs e)
        {
            OnMouseHover(e);
        }

        private void formContent_MouseEnter(object sender, System.EventArgs e)
        {
            OnMouseEnter(e);
        }
    }
}
