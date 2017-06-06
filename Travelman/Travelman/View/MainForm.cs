using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Travelman.API;
using Travelman.Database;
using Travelman.Data;

namespace Travelman.View
{
    public partial class MainForm : MaterialForm
    {
        private StartView _startView;
        private MainView _mainView;
        private readonly ILocationProvider _locationProvider;
        private readonly IPlacesProvider _placesProvider;
        private readonly IDataAccessLayer<Route> _dal;

        /// <summary>
        /// The maximum amount of time in milliseconds between API requests, used by the exponential fallback technique.
        /// </summary>
        private const int MaxDelay = 3600000;

        public MainForm()
        {
            _locationProvider = GoogleHttp.Instance();
            _placesProvider = GoogleHttp.Instance();

            IDatabase database = new SqlServerCe();
            _dal = new RouteDataAccessLayer(database);

            var m = MaterialSkinManager.Instance;
            m.AddFormToManage(this);
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500,
                Accent.LightBlue200, TextShade.WHITE);

            AutoScaleMode = AutoScaleMode.None;

            InitializeComponent();
            ShowStartView();
        }


        public bool PlanTrip(string start, string destination)
        {
            if (start.Equals(destination) || delayBetweenRequests.Enabled) return false; // Avoid spam

            if (_locationProvider.RouteIsPossible(start, destination))
            {
                formContent.Controls.Remove(_startView);
                KeyDown -= _startView.HandleKeys;
                _startView.Dispose();

                ShowMainView(start, destination);
                return true;
            }

            // Exponential backoff to avoid spamming
            delayBetweenRequests.Interval = Math.Min(delayBetweenRequests.Interval * 2, MaxDelay);

            delayBetweenRequests.Start();
            return false;
        }

        private void ShowStartView()
        {
            _startView = new StartView(_locationProvider, PlanTrip) { Dock = DockStyle.Fill };
            KeyDown += _startView.HandleKeys;
            formContent.Controls.Add(_startView);
        }

        private void ShowMainView(string start, string destination)
        {
            _mainView = new MainView(this, _locationProvider, _placesProvider, _dal, start, destination) { Dock = DockStyle.Fill };
            formContent.Controls.Add(_mainView);
        }

        public void StartOver()
        {
            formContent.Controls.Remove(_mainView);
            _mainView.Dispose();

            ShowStartView();
        }

        private void DelayBetweenRequests_Tick(object sender, EventArgs e)
        {
            delayBetweenRequests.Enabled = false;
        }
    }
}