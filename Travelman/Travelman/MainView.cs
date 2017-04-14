using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace Travelman
{
    public partial class MainView : UserControl
    {
        private const bool SIDEBAR_SHOWN = true;
        private ChromiumWebBrowser _browser;

        public MainView()
        {
            Dock = DockStyle.Fill;
            InitializeComponent();
            InitializeBrowser();
            Disposed += MainView_Disposed;
            scSidebar.Panel1Collapsed = SIDEBAR_SHOWN;
        }

        private void MainView_Disposed(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }

        private void InitializeBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            string url = string.Format(@"{0}\html\index.html", Application.StartupPath);
            _browser = new ChromiumWebBrowser(url);
            scSidebar.Panel2.Controls.Add(_browser);
            _browser.Dock = DockStyle.Fill;

            // Allow local files
            _browser.BrowserSettings = new BrowserSettings()
            {
                FileAccessFromFileUrls = CefState.Enabled,
                UniversalAccessFromFileUrls = CefState.Enabled
            };
        }
    }
}
