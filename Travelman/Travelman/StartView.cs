using System;
using System.Drawing;
using System.Windows.Forms;

namespace Travelman
{
    public partial class StartView : UserControl
    {
        private MainForm _parent;
        private LocationSelection _start, _destination;
        public bool StartFilled { get; set; }
        public bool DestinationFilled { get; set; }

        public StartView(MainForm parent)
        {
            _parent = parent;
            InitializeComponent();

            _destination = new LocationSelection(LocationPanel, new Point(0, 48), "Kies een bestemming...", FontAwesome.Sharp.IconChar.FlagCheckered, 2);
            _destination.Validated += ValidateTextFields;
            LocationPanel.Controls.Add(_destination);

            _start = new LocationSelection(LocationPanel, new Point(0, 0), "Kies een vertrekpunt...", FontAwesome.Sharp.IconChar.FlagO, 2);
            _start.Validated += ValidateTextFields;
            LocationPanel.Controls.Add(_start);
        }

        /// <summary>
        /// Enables the plan trip button when user has filled both fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateTextFields(object sender, EventArgs e)
        {
            btnPlanTrip.Enabled = _start.IsFilled() && _destination.IsFilled();
        }

        private void btnPlanTrip_Click(object sender, EventArgs e)
        {
            if(!_parent.PlanTrip(_start.GetInput(), _destination.GetInput()))
            {
                lblInvalidLocation.Visible = true;
            }
        }
    }
}
