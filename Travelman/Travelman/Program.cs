using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Extension method: truncates (shortens) a string to fit within the specified number of characters.
        /// If the string is too big, three dots will be added to signify the truncation.
        /// Example: "Empire State Building" could turn into "Empire State Bui..."
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TruncateString(this string value, int maxLength)
        {
            if (value.Length <= maxLength) return value;
            return value.Substring(0, maxLength) + '\u2026'; // Ellipsis symbol (shorthand ...)
        }
    }
}