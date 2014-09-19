using System.ServiceModel;

namespace Compucare.Enquire.Common.Communication.Interfaces
{
    [ServiceContract]
    public interface IStatusService
    {
        [OperationContract]
        ServerStatus GetServerStatus(ServerVariables variable);
    }

}
