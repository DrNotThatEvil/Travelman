using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Travelman.Data;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Travelman.Components
{
    public partial class RouteList : UserControl
    {
        public RouteList()
        {
            InitializeComponent();

            var closeButton = new IconButton
            {
                Location = new Point(Width - 40, 8),
                Size = new Size(32, 32),
                Icon = IconChar.Times,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat,
                Enabled = true
            };
            closeButton.Click += Close;
            panel.Controls.Add(closeButton);
        }

        public void UpdateRouteList(List<Route> routes, Action<Route> showRouteAction, Action<Route> deleteRouteAction)
        {
            lblNoRoutesToDisplay.Visible = routes.Count == 0;

            panelListContainer.Controls.Clear();
            
            int y = 0;
            foreach (Route route in routes)
            {
                RouteListItem item = new RouteListItem(route, showRouteAction, deleteRouteAction, Close)
                {
                    Location = new Point(0, y)
                };
                panelListContainer.Controls.Add(item);
                y += item.Height + 1;
            }
        }

        private void Close(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
