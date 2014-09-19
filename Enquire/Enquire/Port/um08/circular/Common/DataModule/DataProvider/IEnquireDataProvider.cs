using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataSource;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataProvider
{
    public interface IEnquireDataProvider
    {
        List<IEnquireDataSource> DataSources { get; }

        String Identifier { get; }

        String DisplayName { get; }

        String Description { get; }

        IEnquireDataSource LoadDataSource(String displayName, ServerDataConnection connection);
    }
}
