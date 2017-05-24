using System;
using System.Windows.Forms;
using Travelman.Data;

namespace Travelman.Components
{
    public partial class RouteListItem : UserControl
    {
        public RouteListItem(Route route, Action<Route> showRouteAction, Action<Route> deleteRouteAction, Action<object, EventArgs> closeAction)
        {
            InitializeComponent();
            lblRouteName.Text = route.Name.TruncateString(20);
            lblFromValue.Text = route.Start.TruncateString(16);
            lblToValue.Text = route.Destination.TruncateString(16);
            pbRouteImage.ImageLocation = route.PreviewImageUrl;

            btnShowRoute.Click += delegate { showRouteAction(route); };
            btnShowRoute.Click += delegate { closeAction(this, EventArgs.Empty); };
            btnDeleteRoute.Click += delegate { deleteRouteAction(route); };
        }
    }
}
