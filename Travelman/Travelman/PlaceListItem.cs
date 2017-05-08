using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Travelman
{
    public partial class PlaceListItem : UserControl
    {
        private const int MaxPlaceNameLength = 19;
        private const int MaxAddressLength = 24;
        private const int StarPosY = 69, StarPosX = 3, StarSize = 24;


        public PlaceListItem(Place place)
        {
            InitializeComponent();
            lblName.Text = place.Name.TruncateString(MaxPlaceNameLength);
            lblAddress.Text = place.Vicinity.TruncateString(MaxAddressLength);
            pbLocationIcon.ImageLocation = place.IconUrl;
            pbLocationPicture.ImageLocation = place.PhotoUrl;
            Width -= SystemInformation.VerticalScrollBarWidth;
            ShowRating(place.Rating);
        }

        private void ShowRating(float rating)
        {
            if (rating <= -1.0f) return; // Rating not applicable for this place
            if (rating < 0.0f || rating > 5.0f) throw new ArgumentOutOfRangeException();

            for (int i = 0; i < 5; i++)
            {
                IconChar icon;
                if (rating >= 1.0f)
                {
                    icon = IconChar.Star;
                }
                else if (rating > 0.0f && rating < 1.0f)
                {
                    icon = IconChar.StarHalfO;
                }
                else
                {
                    icon = IconChar.StarO;
                }


                Controls.Add(new IconPictureBox()
                {
                    Location = new Point(StarPosX + (i * StarSize), StarPosY),
                    Size = new Size(StarSize, StarSize),
                    IconChar = icon,
                    //SizeMode = PictureBoxSizeMode.CenterImage,
                    Enabled = false
                });
                rating--;
            }
        }
    }
}