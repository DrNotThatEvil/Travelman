using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Travelman
{
    public partial class PlaceListItem : UserControl
    {
        private const int MaxPlaceNameLength = 17;
        private const int MaxAddressLength = 24;
        private const int StarPosY = 69, StarPosX = 3, StarSize = 24;
        private readonly int _index;

        public PlaceListItem(Place place, int index, Action<int> action)
        {
            _index = index;
            InitializeComponent();
            lblName.Text = _index + ": " + TruncateString(place.Name, MaxPlaceNameLength);
            lblAddress.Text = TruncateString(place.Vicinity, MaxAddressLength);
            pbLocationIcon.ImageLocation = place.IconUrl;
            pbLocationPicture.ImageLocation = place.PhotoUrl;
            Width -= SystemInformation.VerticalScrollBarWidth;
            Click += delegate { action(_index); };
            ShowRating(place.Rating);
        }

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        public int GetIndex()
        {
            return _index;
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
                    Enabled = false
                });
                rating--;
            }
        }

        /// <summary>
        /// Truncates (shortens) a string to fit within the specified number of characters.
        /// If the string is too big, three dots will be added to signify the truncation.
        /// Example: "Empire State Building" could turn into "Empire State Bui..."
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength">Number of characters excluding ellipsis symbol</param>
        /// <returns></returns>
        private static string TruncateString(string str, int maxLength)
        {
            if (str.Length <= maxLength) return str;
            return str.Substring(0, maxLength) + '\u2026'; // Ellipsis symbol (shorthand ...)
        }
    }
}