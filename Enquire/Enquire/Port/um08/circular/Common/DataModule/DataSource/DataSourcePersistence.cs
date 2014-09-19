using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Compucare.Enquire.Common.DataModule.DataProvider;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataSource
{
    public class DataSourcePersistence
    {
        private readonly ServerDataConnection _server;

        public DataSourcePersistence(ServerDataConnection server)
        {
            _server = server;
        }

        public List<IEnquireDataSource> GetSourceList(IEnquireDataProvider provider)
        {
            List<IEnquireDataSource> retVal = new List<IEnquireDataSource>();

            SQLiteCommand cmd = _server.CreateCommand();

            cmd.CommandText = String.Format(@"SELECT Identifier from DataSources WHERE DataProviderIdentifier = :PROVIDERID order by Identifier desc");

            cmd.Parameters.AddWithValue("PROVIDERID", provider.Identifier);

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                retVal.Add(BaseDataSource.Load(_server, reader.GetString(0)));
            }

            return retVal;
        }
    }
}
