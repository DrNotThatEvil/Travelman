using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travelman
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();
            InitializeBrowser();
            //this.Controls.Add(new LocationSelection("Startpunt"));
        }

        
        private void InitializeBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            string url = string.Format(@"{0}\html\index.html", Application.StartupPath);

            if (!File.Exists(url)) { MessageBox.Show("Error"); }

            browser = new ChromiumWebBrowser(url);
            Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            // Allow local files
            browser.BrowserSettings = new BrowserSettings()
            {
                FileAccessFromFileUrls = CefState.Enabled,
                UniversalAccessFromFileUrls = CefState.Enabled
            };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
