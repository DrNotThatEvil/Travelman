using System;
using System.Drawing;
using System.Windows.Forms;
using Travelman.API;
using Travelman.Components;

namespace Travelman.View
{
    public partial class StartView : UserControl
    {
        private readonly LocationSelection _start, _destination;
        private readonly Func<string, string, bool> _planTripFunc;
        private bool _canPlanTrip;
        
        public StartView(ILocationProvider locationProvider, Func<string, string, bool> planTripFunc)
        {
            _planTripFunc = planTripFunc;
            InitializeComponent();

            _destination = new LocationSelection(LocationPanel, locationProvider, new Point(0, 48), "Choose a destination...",
                FontAwesome.Sharp.IconChar.FlagCheckered, 3);
            _destination.InputChanged += InputsChanged;
            LocationPanel.Controls.Add(_destination);

            _start = new LocationSelection(LocationPanel, locationProvider, new Point(0, 0), "Choose a starting point...",
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
                    if (_canPlanTrip) PlanTrip();
                    break;
            }
        }

        private void StartView_Click(object sender, EventArgs e)
        {
            HideAutocompletion();
        }

        private void PlanTrip_Click(object sender, EventArgs e)
        {
            PlanTrip();
        }

        private void HideAutocompletion()
        {
            _start.HideAutocompletion();
            _destination.HideAutocompletion();
        }

        private void PlanTrip()
        {
            if (!_canPlanTrip)
            {
                ShowError("Error: Please fill in the form.");
                return;
            }

            if (!_planTripFunc(_start.Input, _destination.Input))
            {
                ShowError("Error: Unable to plan route");
            }   
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}