using System;
using System.Windows.Forms;

namespace Travelman
{
    public partial class LocationSelection : UserControl
    {
        private readonly string _placeholder;

        public LocationSelection(string placeholder)
        {
            _placeholder = placeholder;
            InitializeComponent();
            tbInput.Text = placeholder;
            tbInput.GotFocus += ClearInput;
            tbInput.LostFocus += AddPlaceholder;
        }

        public void ClearInput(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }

        public void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInput.Text))
            {
                tbInput.Text = _placeholder;
            }
        }
    }
}
