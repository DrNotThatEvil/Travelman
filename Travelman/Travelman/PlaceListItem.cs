using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travelman
{
    public partial class PlaceListItem : UserControl
    {
        public PlaceListItem(Place place)
        {
            InitializeComponent();
            lblName.Text = place.Name;
            lblAddress.Text = place.Vicinity;
            pbLocationIcon.ImageLocation = place.IconUrl;
            Width -= SystemInformation.VerticalScrollBarWidth;
        }
    }
}
