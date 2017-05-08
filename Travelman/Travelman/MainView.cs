using System;
using System.Collections;
using System.Collections.Generic;
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
            _destination.Input = destination;
            _destination.AutocompleteOptionSelected += AutocompleteOptionSelected;
            scSidebarHorizontal.Panel1.Controls.Add(_destination);

            _start = new LocationSelection(scSidebar.Panel1, new Point(0, 0), "", FontAwesome.Sharp.IconChar.FlagO, 5);
            _start.Input = start;
            _start.AutocompleteOptionSelected += AutocompleteOptionSelected;
            scSidebarHorizontal.Panel1.Controls.Add(_start);

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
                case Keys.Tab:
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
                GetNearbyPlaces();
            }
        }

        private void ShowRoute()
        {
            if (_browser.IsBrowserInitialized)
            {
                _browser.ExecuteScriptAsync("showRoute", _start.Input, _destination.Input);
            }
        }

        private async void GetNearbyPlaces()
        {
            // Clear nearby places list
            Invoke((MethodInvoker)delegate {
                scSidebarHorizontal.Panel2.Controls.Clear(); // Invoke to call method on UI thread
            });

            ICollection<Place> places = await GoogleHttp.Instance().GetNearbyPlaces(_start.Input, 1000);
            places = GoogleHttp.Instance().GetPhotosOfPlaces(places, 90, 90);
            Point location = new Point();
            foreach (Place place in places)
            {
                PlaceListItem item = new PlaceListItem(place) { Location = location };
                Invoke((MethodInvoker)delegate {
                    scSidebarHorizontal.Panel2.Controls.Add(item); // Add control on UI thread
                });
                location.Y += 98;
            }
        }

        private void HideAutocompletion()
        {
            _start.HideAutocompletion();
            _destination.HideAutocompletion();
        }       
    }
}
