using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Compucare.Enquire.Common.Communication.Interfaces;
using Compucare.Enquire.Common.PersistenceModule.Server;
using Compucare.Enquire.EnquireServer.Communication;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.EnquireServer
{
    public class EnquireServer
    {
        private String _status;

        internal IStatusService StatusService { get; private set; }
        internal ServerDataConnection ServerDataConnection { get; set; }

        public String Status
        {
            get { return _status; }
            set { _status = value; EventHelper.Fire(StatusChanged); }
        }

        public event CommonEventHandler StatusChanged;

        public IList<ServiceHost> ServiceHosts { get; set; }

        public EnquireServer()
        {
            ServiceHosts = new List<ServiceHost>();
            StatusService = new StatusService();

            Status = "Initialised";
        }

        public void Initialize()
        {
            Status = "Ready";
        }
    }
}
