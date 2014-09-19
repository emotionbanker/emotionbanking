using System;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using Compucare.Frontends.Common.Forms;

namespace Compucare.Enquire.Legacy.Umfrage2Gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            Application.ThreadException += ApplicationThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionVisualiser.Show(e.Exception);
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                ExceptionVisualiser.Show((Exception)e.ExceptionObject);
            }
        }
    }
}
