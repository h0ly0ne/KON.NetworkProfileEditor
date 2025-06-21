using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace KON.NetworkProfileEditor
{
    [SupportedOSPlatform("windows7.0")]
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(new MainForm());
        }
    }
}