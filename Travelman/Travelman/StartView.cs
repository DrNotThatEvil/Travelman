using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travelman
{
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
            LocationPanel.Controls.Add(
                new LocationSelection(LocationPanel, new Point(0, 48), "Kies een bestemming...", FontAwesome.Sharp.IconChar.FlagCheckered, 2)
            );

            LocationPanel.Controls.Add(
                new LocationSelection(LocationPanel, new Point(0, 0), "Kies een vertrekpunt...", FontAwesome.Sharp.IconChar.FlagO, 2)
            );
            
        }

        private void StartView_Click(object sender, EventArgs e)
        {
            
        }
    }

    
}
