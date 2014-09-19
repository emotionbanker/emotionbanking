using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataProvider;
using Compucare.Enquire.Common.DataModule.DataSource;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.File.Um3
{
    public class FileUm3DataProvider : BaseEnquireDataProvider
    {
        public const String DefaultDescription = "Data retrieved from an UM3 file.";

        private String _fileName;

        public FileUm3DataProvider()
        {
        }

        public FileUm3DataProvider(String filename)
        {
            _fileName = filename;
            Identifier = Guid.NewGuid().ToString("D");
        }

        protected override string GetProviderData()
        {
            return _fileName;
        }

        protected override void SetProviderData(string providerData)
        {
            _fileName = providerData;
        }

        public override IEnquireDataSource LoadDataSource(String displayName, ServerDataConnection connection)
        {
            FileUm3DataSource source = new FileUm3DataSource();



            source.Description = DefaultDescription;
            source.Identifier = Guid.NewGuid().ToString("D");
            source.DisplayName = displayName;
            source.LocalPersistence = LocalPersistencePrefix + source.Identifier;
            source.DataProviderIdentifier = Identifier;
            source.Status = "WAITING";

            source.Store(connection);

            DataSources.Add(source);

            return source;
        }
    }
}
