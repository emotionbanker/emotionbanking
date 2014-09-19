using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Compucare.Enquire.Common.PersistenceModule.Server;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.EnquireServer.Commands
{
    public class InitServerDBCommand : BaseCommand
    {
        public InitServerDBCommand()
        {
            Identifier = "Initiate server database...";
        }

        public override void CustomProcess()
        {
            ServerDataConnection conn = new ServerDataConnection();

            try
            {
                conn.OpenConnection();
                ReturnValue = conn;
                Result = CommandResult.Ok;
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to open database connection.", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Result = CommandResult.Failed;
            }
        }
    }
}
