using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.EnquireServer.Commands
{
    public class InitStatusServiceCommand : BaseCommand
    {
        private readonly EnquireServer _server;
        private readonly double _timeout;

        public InitStatusServiceCommand(EnquireServer server, double timeoutInMs)
        {
            _server = server;
            _timeout = timeoutInMs;
            Identifier = "Initiate status service...";
        }

        public override void CustomProcess()
        {
            try
            {
                ServiceHost host = new ServiceHost(_server.StatusService);

                new Thread(host.Open).Start();

                double interval = 250;

                double waitSteps = _timeout/interval;
                double progressStep = 100/waitSteps;

                double timeout = _timeout;
                while (host.State != CommunicationState.Opened
                       && timeout > 0)
                {
                    Thread.Sleep((int)interval);
                    timeout-=interval;

                    Status += progressStep;
                }

                Result = (host.State == CommunicationState.Opened)
                             ? CommandResult.Ok
                             : CommandResult.Failed;

                ReturnValue = host;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
        }
    }
}
