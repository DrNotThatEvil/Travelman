using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Travelman
{
    public partial class MainForm : MaterialForm
    {
        private StartView _startView;
        private MainView _mainView;

        public MainForm()
        {
            // Initialize MaterialSkinManager
            MaterialSkinManager m = MaterialSkinManager.Instance;
            m.AddFormToManage(this);
            m.Theme = MaterialSkinManager.Themes.LIGHT;
            m.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

            // Show startview
            _startView = new StartView(this) { Dock = DockStyle.Fill };
            formContent.Controls.Add(_startView);
        }

        public bool PlanTrip(string start, string destination)
        {
            ILocationProvider locationProvider = GoogleHTTP.Instance();
            // TODO: Handle start == destination
            // TODO: Trip too long / destination unreachable
            // TODO: Anti-spam
            if (locationProvider.LocationIsValid(start) && locationProvider.LocationIsValid(destination))
            {
                formContent.Controls.Remove(_startView);
                _startView.Dispose();

                // Show mainview
                _mainView = new MainView(start, destination);
                formContent.Controls.Add(_mainView);
                return true;
            }
            return false;
        }
    }
}
