using System;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;
using Compucare.Frontends.Common.Identity;

namespace Compucare.Enquire.EnquireStudio
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

            CompucareSplashController splash = new CompucareSplashController(new CompucareSplash(), "Enquire 2011", "Enquire Studio", "2005 - 2011", "",
                new CommandController(), new WaitCommand(0.1), new Image[0]);

            splash.ShowSplash();

            Application.Run(new MainForm());
        }
    }
}
