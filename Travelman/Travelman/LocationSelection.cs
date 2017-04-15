using System;
using System.Collections.Generic;
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
        

        public LocationSelection(string placeholder, string fontawesomeIcon, int maxItemsDisplayed)
        {
            if (maxItemsDisplayed <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _maxHeight = maxItemsDisplayed * ITEM_HEIGHT;

            _placeholder = placeholder;
            InitializeComponent();

            // Avoid horizontal scroll bar
            ColumnHeader colh = new ColumnHeader();
            colh.Width = materialListView1.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            materialListView1.Columns.Add(colh);

            // Set flag icon
            FontAwesomeFont.Reload(20);
            lblIcon.Text = fontawesomeIcon;
            lblIcon.Font = FontAwesomeFont.FontAwesome;

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

            materialListView1.Items.Clear();
            foreach (string suggestion in suggestions)
            {
                materialListView1.Items.Add(suggestion);
            }

            materialListView1.Height = Math.Min(suggestions.Count * ITEM_HEIGHT, _maxHeight);
        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Text = materialListView1.SelectedItems[0].Text;
            _isDirty = false;
            timerAutocompleteRequest.Stop();

            materialListView1.Height = 0;
        }
    }
}
