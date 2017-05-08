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

        public StartView(MainForm parent, ILocationProvider locationProvider)
        {
            _parent = parent;
            InitializeComponent();

            _destination = new LocationSelection(LocationPanel, locationProvider, new Point(0, 48), "Kies een bestemming...",
                FontAwesome.Sharp.IconChar.FlagCheckered, 3);
            _destination.InputChanged += InputsChanged;
            LocationPanel.Controls.Add(_destination);

            _start = new LocationSelection(LocationPanel, locationProvider, new Point(0, 0), "Kies een vertrekpunt...",
                FontAwesome.Sharp.IconChar.FlagO, 3);
            _start.InputChanged += InputsChanged;
            LocationPanel.Controls.Add(_start);

            btnPlanTrip.Select();
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

        public void HandleKeys(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Escape:
                    HideAutocompletion();
                    break;
                case Keys.Enter:
                    if (_canPlanTrip)
                    {
                        PlanTrip();
                    }
                    break;
            }
        }

        private void StartView_Click(object sender, EventArgs e)
        {
            HideAutocompletion();
        }

        private void HideAutocompletion()
        {
            _start.HideAutocompletion();
            _destination.HideAutocompletion();
        }

        private void btnPlanTrip_Click(object sender, EventArgs e)
        {
            if (_canPlanTrip) PlanTrip();
        }

        private void PlanTrip()
        {
            if (!_parent.PlanTrip(_start.Input, _destination.Input))
            {
                // Invalid input
                lblInvalidLocation.Visible = true;
            }
        }
    }
}