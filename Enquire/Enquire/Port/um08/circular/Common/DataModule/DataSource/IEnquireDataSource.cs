using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataItem;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataSource
{
    public interface IEnquireDataSource
    {
        String LocalPersistence { get; }

        String Identifier { get; }

        String DisplayName { get; }

        String Description { get; }

        String Status { get; }

        String DataProviderIdentifier { get; }

        void Store(ServerDataConnection server);

        void LoadItem(IEnquireDataItem dataItem);
    }
}
