using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Travelman
{
    public partial class MainForm : MaterialForm
    {
        private readonly StartView _startView;
        private MainView _mainView;
        private readonly ILocationProvider _locationProvider;

        /// <summary>
        /// The maximum amount of time in milliseconds between API requests, used by the exponential fallback technique.
        /// 3600000 ms = 1 hour
        /// </summary>
        private const int MaxDelay = 3600000;

        public MainForm()
        {
            // Initialize MaterialSkinManager
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.AddFormToManage(this);
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500,
                Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

            _locationProvider = GoogleHttp.Instance();

            // Show startview
            _startView = new StartView(this) {Dock = DockStyle.Fill};
            formContent.Controls.Add(_startView);
        }


        public bool PlanTrip(string start, string destination)
        {
            if (start.Equals(destination) || delayBetweenRequests.Enabled) return false; // Avoid spam

            if (_locationProvider.RouteIsPossible(start, destination))
            {
                formContent.Controls.Remove(_startView);
                _startView.Dispose();

                // Show mainview
                _mainView = new MainView(this, start, destination) {Dock = DockStyle.Fill};
                formContent.Controls.Add(_mainView);
                return true;
            }

            // Exponential backoff to avoid spamming
            delayBetweenRequests.Interval = Math.Min(delayBetweenRequests.Interval * 2, MaxDelay);

            delayBetweenRequests.Start();
            return false;
        }

        private void delayBetweenRequests_Tick(object sender, EventArgs e)
        {
            delayBetweenRequests.Enabled = false;
        }
    }
}