using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travelman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Cef.Initialize();
            ChromiumWebBrowser myBrowser = new ChromiumWebBrowser("http://www.maps.google.com");
            this.Controls.Add(myBrowser);
            InitializeComponent();
            this.Controls.Add(new LocationSelection("Startpunt"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
