using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            //dynamic output = await GoogleHTTP.Instance().getAutocompleteList("kaas");
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

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            bool isDirty = tbInput.Text != _placeholder;
            bool isEmpty = tbInput.Text == string.Empty;
            bool shouldAutocomplete = isDirty && !isEmpty && !timerAutocompleteRequest.Enabled;

            if (shouldAutocomplete)
            {
                timerAutocompleteRequest.Start();
            }
            //this.Controls.Add(new LocationAutocompleteOption());
        }

        private void timerAutocompleteRequestFinished(object sender, EventArgs e)
        {
            timerAutocompleteRequest.Stop();
            ShowAutocompletionSuggestions(tbInput.Text);
        }

        private async void ShowAutocompletionSuggestions(string query)
        {
            List<string> suggestions = await GoogleHTTP.Instance().getAutocompleteList(query);
            materialListView1.Clear();
            foreach (string suggestion in suggestions)
            {
                materialListView1.Items.Add(suggestion);
            }
        }

        public void AutocompletionSuggestionSelected(string location)
        {

        }
    }
}
