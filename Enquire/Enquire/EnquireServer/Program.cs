using System;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Enquire.EnquireServer.Commands;
using Compucare.Frontends.Common.Command;
using Compucare.Frontends.Common.Identity;

namespace Compucare.Enquire.EnquireServer
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

            EnquireServer server = new EnquireServer();
            MainForm mainForm = new MainForm();

            InitServerBatchCommand initServerCommand = new InitServerBatchCommand(CommandBatchMode.SingleThreaded,
                                                                                  server);

            CompucareSplashController splash = new CompucareSplashController(new CompucareSplash(), "Enquire 2011", "Enquire Server", "2005 - 2011", "",
               new CommandController(), initServerCommand, new Image[0]);

            splash.ShowSplash();

            if (initServerCommand.Result != CommandResult.Ok)
            {
                MessageBox.Show("Failed to initialise server.\r\n", "Fatal error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                MainFormController mainFormController = new MainFormController(mainForm, server);
                server.Initialize();
                Application.Run(mainForm);                
            }
        }
    }
}
