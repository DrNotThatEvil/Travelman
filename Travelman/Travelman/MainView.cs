using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Drawing;

namespace Travelman
{
    public partial class MainView : UserControl
    {
        private const bool SidebarShown = true;
        private ChromiumWebBrowser _browser;
        private readonly LocationSelection _start, _destination;

        public MainView(Control parent, string start, string destination)
        {
            InitializeComponent();
            InitializeBrowser();
            Disposed += MainView_Disposed;
            parent.KeyDown += HandleKeys;

            _destination = new LocationSelection(scSidebar.Panel1, new Point(0, 48), "", FontAwesome.Sharp.IconChar.FlagCheckered, 5);
            _destination.SetInput(destination);
            _destination.AutocompleteOptionSelected += AutocompleteOptionSelected;
            scSidebar.Panel1.Controls.Add(_destination);

            _start = new LocationSelection(scSidebar.Panel1, new Point(0, 0), "", FontAwesome.Sharp.IconChar.FlagO, 5);
            _start.SetInput(start);
            _start.AutocompleteOptionSelected += AutocompleteOptionSelected;
            scSidebar.Panel1.Controls.Add(_start);

            scSidebar.Panel1Collapsed = !SidebarShown;
        }

        private static void MainView_Disposed(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }

        private void AutocompleteOptionSelected(object sender, EventArgs e)
        {
            if (!_start.IsFilled() || !_destination.IsFilled()) return;
            HideAutocompletion();
            ShowRoute();
        }

        private void HandleKeys(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    HideAutocompletion();
                    break;
                case Keys.Enter:
                    if (_start.IsFilled() && _destination.IsFilled())
                    {
                        HideAutocompletion();
                        ShowRoute();
                    }
                    break;
            }
        }

        private void InitializeBrowser()
        {
            var cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            string url = $@"{Application.StartupPath}\html\index.html";
            _browser = new ChromiumWebBrowser(url);
            scSidebar.Panel2.Controls.Add(_browser);
            _browser.Dock = DockStyle.Fill;
            
            // Allow local files
            _browser.BrowserSettings = new BrowserSettings()
            {
                FileAccessFromFileUrls = CefState.Enabled,
                UniversalAccessFromFileUrls = CefState.Enabled
            };
            _browser.FrameLoadEnd += BrowserFrameLoadEnd;
            _browser.SendToBack();
        }

        private void BrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                ShowRoute();
            }
        }

        private void ShowRoute()
        {
            if (_browser.IsBrowserInitialized)
            {
                _browser.ExecuteScriptAsync("showRoute", _start.GetInput(), _destination.GetInput());
            }
        }

        private void HideAutocompletion()
        {
            _start.HideAutocompletion();
            _destination.HideAutocompletion();
        }       
    }
}
