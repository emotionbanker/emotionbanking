using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataProvider
{
    public class DataProviderPersistence
    {
        private ServerDataConnection _server;

        public DataProviderPersistence(ServerDataConnection server)
        {
            _server = server;
        }

        public void AddDataProvider(BaseEnquireDataProvider provider)
        {
            provider.Store(_server);
        }

        public List<BaseEnquireDataProvider> GetProviderList()
        {
            List<BaseEnquireDataProvider> retVal = new List<BaseEnquireDataProvider>();

            SQLiteCommand cmd = _server.CreateCommand();

            cmd.CommandText = String.Format(@"SELECT Identifier from DataProviders;");

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                retVal.Add(BaseEnquireDataProvider.Load(_server, reader.GetString(0)));
            }

            return retVal;
        }
    }
}
