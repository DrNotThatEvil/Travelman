using FontAwesome.Sharp;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Travelman
{
    public partial class LocationSelection : UserControl
    {
        /// <summary>
        /// Height in pixels of an autocomplete suggestion.
        /// </summary>
        private const int ItemHeight = 41;

        /// <summary>
        /// The default text of the text field.
        /// </summary>
        private readonly string _placeholder;

        /// <summary>
        /// Is false when the user has edited the text field.
        /// </summary>
        private bool _isDirty;

        /// <summary>
        /// Maximum height of the autcomplete suggestion list.
        /// </summary>
        private readonly int _maxHeight;

        /// <summary>
        /// A MaterialSkin-style ListView control used for showing autocompletion options to the user.
        /// </summary>
        private readonly MaterialListView _autocompleteList;

        /// <summary>
        /// Used in gathering autocompletion suggestions.
        /// </summary>
        private readonly ILocationProvider _locationProvider;

        /// <summary>
        /// Event raised by this user control when tbInput text has been changed by the program or the user.
        /// </summary>
        public event EventHandler InputChanged
        {
            add => tbInput.TextChanged += value;
            remove => tbInput.TextChanged -= value;
        }

        public event EventHandler AutocompleteOptionSelected;

        public string Input
        {
            get => tbInput.Text;
            set
            {
                tbInput.Text = value;
                // Avoid autocomplete popup
                HideAutocompletion();
            }
        }

        public LocationSelection(Control parent, Point location, string placeholder, IconChar icon,
            int maxAutcompleteItemsDisplayed)
        {
            if (maxAutcompleteItemsDisplayed <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _maxHeight = maxAutcompleteItemsDisplayed * ItemHeight;
            _placeholder = placeholder;
            Location = location;

            InitializeComponent();

            _locationProvider = GoogleHttp.Instance();

            // Create list view at parent
            Point listViewLocation = new Point(panelInput.Location.X, panelInput.Location.Y + panelInput.Size.Height);
            listViewLocation.Offset(Location);
            _autocompleteList = new MaterialListView()
            {
                Cursor = Cursors.Hand,
                FullRowSelect = true,
                MultiSelect = false,
                HeaderStyle = ColumnHeaderStyle.None,
                OwnerDraw = true,
                ShowGroups = false,
                TabStop = false,
                View = View.Details,
                Location = listViewLocation,
                Size = new Size(288, 0)
            };
            _autocompleteList.SelectedIndexChanged += autocompleteList_SelectedIndexChanged;
            parent.Controls.Add(_autocompleteList);

            // Avoid horizontal scroll bar
            ColumnHeader colh = new ColumnHeader
            {
                Width = _autocompleteList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth
            };
            _autocompleteList.Columns.Add(colh);

            // Create flag icon
            panelInput.Controls.Add(new IconPictureBox()
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

        /// <summary>
        /// Returns true if the textbox has been altered by the user to be a non-default value.
        /// </summary>
        /// <returns></returns>
        public bool IsFilled()
        {
            return tbInput.Text != string.Empty && tbInput.Text != _placeholder;
        }

        public void ClearInput(object sender, EventArgs e)
        {
            if (tbInput.Text == _placeholder)
            {
                tbInput.Text = "";
            }
        }

        public void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInput.Text))
            {
                tbInput.Text = _placeholder;
            }
        }

        private bool ShouldAutocomplete()
        {
            if (tbInput.Text != _placeholder)
            {
                _isDirty = true;
            }

            bool isEmpty = tbInput.Text == string.Empty;

            return _isDirty && !isEmpty && !timerAutocompleteRequest.Enabled;
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (ShouldAutocomplete())
            {
                timerAutocompleteRequest.Start();
            }
        }

        private void tbInput_Leave(object sender, EventArgs e)
        {
            HideAutocompletion();
        }

        private void TimerAutocompleteRequestFinished(object sender, EventArgs e)
        {
            timerAutocompleteRequest.Stop();
            ShowAutocompletion(tbInput.Text);
        }

        private async void ShowAutocompletion(string query)
        {
            List<string> suggestions = await _locationProvider.GetAutocompleteList(query);

            if (!ContainsFocus) return; // Handle edge case where user unfocuses control before getting response

            _autocompleteList.Items.Clear();
            foreach (string suggestion in suggestions)
            {
                _autocompleteList.Items.Add(suggestion);
            }

            _autocompleteList.Height = Math.Min(suggestions.Count * ItemHeight, _maxHeight);
            _autocompleteList.BringToFront();
        }

        public void HideAutocompletion()
        {
            timerAutocompleteRequest.Stop();
            _autocompleteList.Height = 0;
        }

        private void autocompleteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Text = _autocompleteList.SelectedItems[0].Text;
            _isDirty = false;
            HideAutocompletion();
            AutocompleteOptionSelected?.Invoke(sender, e);
        }
    }
}