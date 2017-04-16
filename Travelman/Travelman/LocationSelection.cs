using FontAwesome.Sharp;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travelman
{
    public partial class LocationSelection : UserControl
    {
        private const int ITEM_HEIGHT = 41;
        private readonly string _placeholder;
        private bool _isDirty;
        private int _maxHeight;
        private Control _parent;
        private MaterialListView _autocompleteList;

        

        public LocationSelection(Control parent, Point location, string placeholder, IconChar icon, int maxAutcompleteItemsDisplayed)
        {
            if (maxAutcompleteItemsDisplayed <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _maxHeight = maxAutcompleteItemsDisplayed * ITEM_HEIGHT;
            _parent = parent;
            _placeholder = placeholder;
            Location = location;

            InitializeComponent();

            // Create list view at parent
            Point listViewLocation = new Point(3, 51);
            listViewLocation.Offset(Location);
            //listViewLocation.Offset(new Point(28, 109));
            _autocompleteList = new MaterialListView()
            {
                Cursor = Cursors.Hand,
                FullRowSelect = true,
                MultiSelect = false,
                HeaderStyle = ColumnHeaderStyle.None,
                OwnerDraw = true,
                ShowGroups = false,
                TabIndex = 0,
                View = View.Details,
                Location = listViewLocation,
                Size = new Size(288, 0)
            };
            _autocompleteList.SelectedIndexChanged += autocompleteList_SelectedIndexChanged;
            _parent.Controls.Add(_autocompleteList);

            // Avoid horizontal scroll bar
            ColumnHeader colh = new ColumnHeader();
            colh.Width = _autocompleteList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            _autocompleteList.Columns.Add(colh);

            // Create flag icon
            panel1.Controls.Add(new IconPictureBox()
            {
                Location = new Point(8, 8),
                Size = new Size(32, 32),
                IconChar = icon,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Enabled = false
            });

            // Prepare placeholder text and register EventHandlers
            tbInput.Text = placeholder;
            tbInput.GotFocus += ClearInput;
            tbInput.LostFocus += AddPlaceholder;
        }

        public void ClearInput(object sender, EventArgs e)
        {
            tbInput.Text = "";
            tbInput.GotFocus -= ClearInput;
        }

        public void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInput.Text))
            {
                tbInput.Text = _placeholder;
            }
        }

        private bool shouldAutocomplete()
        {
            if (tbInput.Text != _placeholder) { _isDirty = true; }

            bool isEmpty = tbInput.Text == string.Empty;

            return _isDirty && !isEmpty && !timerAutocompleteRequest.Enabled;
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (shouldAutocomplete())
            {
                timerAutocompleteRequest.Start();
            }
        }

        private void timerAutocompleteRequestFinished(object sender, EventArgs e)
        {
            timerAutocompleteRequest.Stop();
            ShowAutocompletionSuggestions(tbInput.Text);
        }

        private async void ShowAutocompletionSuggestions(string query)
        {
            List<string> suggestions = await GoogleHTTP.Instance().getAutocompleteList(query);

            _autocompleteList.Items.Clear();
            foreach (string suggestion in suggestions)
            {
                _autocompleteList.Items.Add(suggestion);
            }

            _autocompleteList.Height = Math.Min(suggestions.Count * ITEM_HEIGHT, _maxHeight);
            _autocompleteList.BringToFront();
        }

        private void autocompleteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Text = _autocompleteList.SelectedItems[0].Text;
            _isDirty = false;
            timerAutocompleteRequest.Stop();

            _autocompleteList.Height = 0;
        }

        private void tbInput_Leave(object sender, EventArgs e)
        {
            _autocompleteList.Height = 0;
        }
    }
}
