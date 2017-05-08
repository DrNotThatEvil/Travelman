using System.Windows.Forms;

namespace Travelman
{
    public partial class PlaceListItem : UserControl
    {
        private const int MaxPlaceNameLength = 19;
        private const int MaxAddressLength = 24;

        public PlaceListItem(Place place)
        {
            InitializeComponent();
            lblName.Text = place.Name.TruncateString(MaxPlaceNameLength);
            lblAddress.Text = place.Vicinity.TruncateString(MaxAddressLength);
            pbLocationIcon.ImageLocation = place.IconUrl;
            pbLocationPicture.ImageLocation = place.PhotoUrl;
            Width -= SystemInformation.VerticalScrollBarWidth;
        }
    }
}
