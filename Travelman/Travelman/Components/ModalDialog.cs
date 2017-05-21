using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Travelman.Components
{
    public partial class ModalDialog : UserControl
    {
        public ModalDialog(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException();

            Width = width;
            Height = height;

            InitializeComponent();

            // Create flag icon
            Controls.Add(new IconButton
            {
                Location = new Point(Width - 40, 8),
                Size = new Size(32, 32),
                Icon = IconChar.Times,
                
                Enabled = true
            });
        }
    }
}
