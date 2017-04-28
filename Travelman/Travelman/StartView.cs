using System;
using System.Drawing;
using System.Windows.Forms;

namespace Travelman
{
    public partial class StartView : UserControl
    {
        private readonly MainForm _parent;
        private readonly LocationSelection _start, _destination;
        private bool _canPlanTrip;

        public StartView(MainForm parent)
        {
            _parent = parent;
            _parent.KeyDown += HandleKeys;
            InitializeComponent();

            _destination = new LocationSelection(LocationPanel, new Point(0, 48), "Kies een bestemming...", FontAwesome.Sharp.IconChar.FlagCheckered, 3);
            _destination.InputChanged += InputsChanged;
            LocationPanel.Controls.Add(_destination);

            _start = new LocationSelection(LocationPanel, new Point(0, 0), "Kies een vertrekpunt...", FontAwesome.Sharp.IconChar.FlagO, 3);
            _start.InputChanged += InputsChanged;
            LocationPanel.Controls.Add(_start);
        }

        /// <summary>
        /// Enables the plan trip button when user has filled both fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputsChanged(object sender, EventArgs e)
        {
            btnPlanTrip.Enabled = _canPlanTrip = _start.IsFilled() && _destination.IsFilled();
        }

        private void HandleKeys(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    HideAutocompletionSuggestions();
                    break;
                case Keys.Enter:
                    if (_canPlanTrip) { PlanTrip(); }
                    break;
            }
        }

        private void StartView_Click(object sender, EventArgs e)
        {
            HideAutocompletionSuggestions();
        }

        private void HideAutocompletionSuggestions()
        {
            _start.HideAutocompletionSuggestions();
            _destination.HideAutocompletionSuggestions();
        }

        private void btnPlanTrip_Click(object sender, EventArgs e)
        {
            PlanTrip();
        }

        private void PlanTrip()
        {
            if (!_parent.PlanTrip(_start.GetInput(), _destination.GetInput()))
            {
                // Invalid input
                lblInvalidLocation.Visible = true;
            }
        }
    }
}
