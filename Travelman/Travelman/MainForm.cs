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
            _startView = new StartView(this) { Dock = DockStyle.Fill };
            formContent.Controls.Add(_startView);
        }

        public bool PlanTrip(string start, string destination)
        {
            GoogleHTTP google = GoogleHTTP.Instance();
            if (google.locationIsValid(start) && google.locationIsValid(destination))
            {
                formContent.Controls.Remove(_startView);
                _startView.Dispose();

                _mainView = new MainView(start, destination);
                formContent.Controls.Add(_mainView);
                return true;
            }
            return false;
        }
    }
}
