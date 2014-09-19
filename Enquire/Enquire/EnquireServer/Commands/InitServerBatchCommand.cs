using System.Collections.Generic;
using System.ServiceModel;
using Compucare.Enquire.Common.PersistenceModule.Server;
using Compucare.Frontends.Common.Command;
using Compucare.Frontends.Common.Identity;

namespace Compucare.Enquire.EnquireServer.Commands
{
    public class InitServerBatchCommand : CommandBatch
    {
        public const double SERVICE_TIMEOUT = 2000;

        public InitServerBatchCommand(CommandBatchMode mode, EnquireServer server)
        {

            IList<ICommand> batch = new List<ICommand>();

            InitStatusServiceCommand status = new InitStatusServiceCommand(server, SERVICE_TIMEOUT);
            InitServerDBCommand serverdb = new InitServerDBCommand();

            status.Finished += () => server.ServiceHosts.Add(status.ReturnValue as ServiceHost);
            serverdb.Finished += () => server.ServerDataConnection = serverdb.ReturnValue as ServerDataConnection;

            batch.Add(status);
            batch.Add(serverdb);
            //batch.Add(new WaitCommand(10) {Identifier = "Starting Server..."});

            _commands = batch;
            _mode = mode;
        }
    }
}
