using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Travelman.API;
using Travelman.Components;
using Travelman.Data;
using Travelman.Database;

namespace Travelman.View
{
    public partial class MainView : UserControl
    {
        private const bool SidebarShown = true;
        private ChromiumWebBrowser _browser;
        private readonly LocationSelection _start, _destination;
        private readonly MainForm _parent;
        private readonly ILocationProvider _locationProvider;
        private readonly IPlacesProvider _placesProvider;
        private readonly IDataAccessLayer<Route> _routeDAL;
        private readonly string _baseUrl = $@"{Application.StartupPath}\Html\index.html";
        private RouteList _routeList;

        public MainView(MainForm parent, ILocationProvider locationProvider, IPlacesProvider placesProvider, IDataAccessLayer<Route> routeDAL, string start, string destination)
        {
            _parent = parent;
            _locationProvider = locationProvider;
            _placesProvider = placesProvider;
            _routeDAL = routeDAL;

            InitializeComponent();
            InitializeBrowser();
            Disposed += MainView_Disposed;
            parent.KeyDown += HandleKeys;

            _destination = new LocationSelection(scSidebar.Panel1, locationProvider, new Point(0, 48), "",
                FontAwesome.Sharp.IconChar.FlagCheckered, 5)
            {
                Input = destination
            };
            _destination.AutocompleteOptionSelected += AutocompleteOptionSelected;
            scSidebarHorizontal.Panel1.Controls.Add(_destination);

            _start = new LocationSelection(scSidebar.Panel1, locationProvider, new Point(0, 0), "", 
                FontAwesome.Sharp.IconChar.FlagO, 5)
            {
                Input = start
            };
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
            ShowRoute(_start.Input, _destination.Input);
            GetNearbyPlaces();
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
                        ShowRoute(_start.Input, _destination.Input);
                        GetNearbyPlaces();
                    }
                    break;
            }
        }

        private void InitializeBrowser()
        {
            var cefSettings = new CefSettings
            {
                RemoteDebuggingPort = 8088
            };
            Cef.Initialize(cefSettings);
            _browser = new ChromiumWebBrowser(_baseUrl);
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
            if (!e.Frame.IsMain) return;
            ShowRoute(_start.Input, _destination.Input);
            GetNearbyPlaces();
        }

        private void ShowRoute(string from, string to)
        {
            if (_browser.IsBrowserInitialized)
            {
                _browser.ExecuteScriptAsync("showRoute", from, to);
            }
        }

        private async void GetNearbyPlaces()
        {
            // Clear nearby places list
            Invoke((MethodInvoker) delegate
            {
                scSidebarHorizontal.Panel2.Controls.Clear(); // Invoke to call method on UI thread
            });

            ICollection<Place> places = await _placesProvider.GetNearbyPlaces(_destination.Input, 50000);
            places = _placesProvider.GetPhotosOfPlaces(places, 90, 90);
            Point location = new Point();
            var index = 1;
            foreach (Place place in places)
            {
                PlaceListItem item = new PlaceListItem(place, index, Item_Click) {Location = location};
                //item.Click += Item_Click;
                Invoke((MethodInvoker) delegate
                {
                    scSidebarHorizontal.Panel2.Controls.Add(item); // Add control on UI thread
                });
                location.Y += 98;

                if (_browser.IsBrowserInitialized)
                {
                    _browser.ExecuteScriptAsync("addMarker", place.GeoCode.Latitude, place.GeoCode.Longitude, index.ToString());
                }
                index++;
            }
        }

        private void Item_Click(int index)
        {
            //Show selected item on the map
            if (_browser.IsBrowserInitialized)
            {
                _browser.ExecuteScriptAsync("selectMarker", index);
            }
        }

        private void StartOver(object sender, EventArgs e)
        {
            _parent.StartOver();
        }

        private void btnMyRoutes_Click(object sender, EventArgs e)
        {
            DisableControls(); // Ensure that user cannot click on anything else

            _routeList = new RouteList();
            _routeList.Disposed += EnableControls; // Re-enable controls after closing dialog

            // Center control, no anchor keeps it that way even after resizing
            _routeList.Location = new Point(Width / 2 - _routeList.Width / 2, Height / 2 - _routeList.Height / 2);
            _routeList.Anchor = AnchorStyles.None;

            UpdateRouteList();

            Controls.Add(_routeList);
            _routeList.BringToFront();
        }

        private void DisableControls()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            }
        }

        private void EnableControls(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }
        }

        private void btnSaveRoute_Click(object sender, EventArgs e)
        {
            DisableControls(); // Ensure that user cannot click on anything else

            SaveRoute sr = new SaveRoute(SaveRouteAction, _start.Input, _destination.Input);
            sr.Disposed += EnableControls; // Re-enable controls after closing dialog

            // Center control, no anchor keeps it that way even after resizing
            sr.Location = new Point(Width / 2 - sr.Width / 2, Height / 2 - sr.Height / 2);
            sr.Anchor = AnchorStyles.None;

            Controls.Add(sr);
            sr.BringToFront();
        }

        private void SaveRouteAction(string name)
        {
            Route r = new Route
            {
                Name = name,
                Start = _start.Input,
                Destination = _destination.Input
            };

            _routeDAL.SaveEntity(r);
        }

        private void ShowRouteAction(Route route)
        {
            EnableControls(null, null);
            _start.Input = route.Start;
            _destination.Input = route.Destination;
            ShowRoute(route.Start, route.Destination);
            GetNearbyPlaces();
        }

        private void DeleteRouteAction(Route route)
        {
            _routeDAL.DeleteEntity(route);
            UpdateRouteList();
        }

        private void UpdateRouteList()
        {
            // Get a list of routes from the database
            List<Route> routes = _routeDAL.GetEntities().ToList();
            routes = _locationProvider.GetPreviewImageOfRoutes(routes, 256, 144);

            _routeList.UpdateRouteList(routes, ShowRouteAction, DeleteRouteAction);
        }

        private void HideAutocompletion()
        {
            _start.HideAutocompletion();
            _destination.HideAutocompletion();
        }
    }
}