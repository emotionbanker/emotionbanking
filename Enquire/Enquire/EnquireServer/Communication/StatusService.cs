using System;
using System.ServiceModel;
using Compucare.Enquire.Common.Communication;
using Compucare.Enquire.Common.Communication.Interfaces;

namespace Compucare.Enquire.EnquireServer.Communication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class StatusService : IStatusService
    {
        public ServerStatus GetServerStatus(ServerVariables variable)
        {
            if (variable == ServerVariables.OpenForBusiness)
            {
                return ServerStatus.Yes;
            }

            return ServerStatus.Unknown;
        }
    }
}
