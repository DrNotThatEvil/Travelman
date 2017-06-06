using System;
using System.Windows.Forms;
using CefSharp;
using Travelman.View;

namespace Travelman
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = System.IO.Path.GetDirectoryName(executable);
            AppDomain.CurrentDomain.SetData("DataDirectory", path); // Used for relative file path of database

            // Prepare browser infrastructure
            var cefSettings = new CefSettings
            {
                RemoteDebuggingPort = 8088
            };
            //cefSettings.CefCommandLineArgs.Add("high-dpi-support", "1");
            //cefSettings.CefCommandLineArgs.Add("force-device-scale-factor", "1");
            Cef.EnableHighDPISupport();
            Cef.Initialize(cefSettings);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Truncates (shortens) a string to fit within the specified number of characters.
        /// If the string is too big, three dots will be added to signify the truncation.
        /// </summary>
        /// <param name="str">String to be shortened</param>
        /// <param name="maxLength">Number of characters excluding ellipsis symbol</param>
        /// <returns></returns>
        public static string TruncateString(this string str, int maxLength)
        {
            if (str.Length <= maxLength) return str;
            return str.Substring(0, maxLength) + '\u2026'; // Ellipsis symbol (shorthand ...)
        }
    }
}