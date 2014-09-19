using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataSource;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataProvider
{
    public abstract class BaseEnquireDataProvider : IEnquireDataProvider
    {
        public const String StoreQueryClear = "DELETE FROM DataProviders WHERE Identifier = :IDENTIFIER";
        public const String StoreQueryInsert = "INSERT INTO DataProviders (Identifier, DisplayName, Description, Type, ProviderData, AssemblyName) VALUES (:IDENTIFIER, :DISPLAYNAME, :DESCRIPTION, :TYPE, :PROVIDERDATA, :ASSEMBLY)";
        public const String LoadQuery = "SELECT Identifier, DisplayName, Description, Type, ProviderData, AssemblyName FROM DataProviders WHERE Identifier = :IDENTIFIER";

        public List<IEnquireDataSource> DataSources { get; set; }

        public String Identifier { get; protected set; }

        public String DisplayName { get; set; }

        public String Description { get; set; }

        protected const String LocalPersistencePrefix = "Persistence/";

        public abstract IEnquireDataSource LoadDataSource(String displayName, ServerDataConnection connection);

        protected abstract String GetProviderData();

        protected abstract void SetProviderData(String providerData);

        public BaseEnquireDataProvider()
        {
            DataSources = new List<IEnquireDataSource>();
        }

        public void Store(ServerDataConnection connection)
        {
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = StoreQueryClear;
            command.Parameters.AddWithValue("IDENTIFIER", Identifier);

            command.ExecuteNonQuery();

            command = connection.CreateCommand();

            command.CommandText = StoreQueryInsert;
            command.Parameters.AddWithValue("IDENTIFIER", Identifier);
            command.Parameters.AddWithValue("DISPLAYNAME", DisplayName ?? "");
            command.Parameters.AddWithValue("DESCRIPTION", Description ?? "");
            command.Parameters.AddWithValue("TYPE", GetType().ToString());
            command.Parameters.AddWithValue("PROVIDERDATA", GetProviderData());
            command.Parameters.AddWithValue("ASSEMBLY",GetType().AssemblyQualifiedName);

            command.ExecuteNonQuery();

            //store sources

            foreach (IEnquireDataSource source in DataSources)
            {
                source.Store(connection);
            }
        }


        public static BaseEnquireDataProvider Load(ServerDataConnection connection, String identifier)
        {
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = LoadQuery;
            command.Parameters.AddWithValue("IDENTIFIER", identifier);

            SQLiteDataReader reader = command.ExecuteReader();

            BaseEnquireDataProvider retVal = null;

            while (reader.Read())
            {
                String typename = reader.GetString(5);

                Type retType = Type.GetType(typename, true, true);

                retVal = (BaseEnquireDataProvider)Activator.CreateInstance(retType);

                retVal.Identifier = identifier;
                retVal.DisplayName = reader.GetString(1);
                retVal.Description = reader.GetString(2);

                retVal.SetProviderData(reader.GetString(4));
            }

            //get sources
            retVal.DataSources.AddRange(new DataSourcePersistence(connection).GetSourceList(retVal));

            return retVal;
        }
    }
}
