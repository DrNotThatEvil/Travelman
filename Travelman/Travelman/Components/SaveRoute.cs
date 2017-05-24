using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Travelman.Components
{
    public partial class SaveRoute : UserControl
    {
        public SaveRoute(Action<string> saveAction, string from, string to)
        {
            InitializeComponent();

            tfFrom.Text = from;
            tfTo.Text = to;

            var closeButton = new IconButton
            {
                Location = new Point(Width - 40, 8),
                Size = new Size(32, 32),
                Icon = IconChar.Times,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Enabled = true
            };
            closeButton.Click += Close;
            panel.Controls.Add(closeButton);

            btnSaveRoute.Click += delegate { saveAction(tfName.Text); };
            btnSaveRoute.Click += Close;

        }

        private void Close(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
