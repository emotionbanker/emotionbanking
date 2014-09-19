using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataItem;
using Compucare.Enquire.Common.PersistenceModule.Server;

namespace Compucare.Enquire.Common.DataModule.DataSource
{
    public class BaseDataSource : IEnquireDataSource
    {
        public const String StoreQueryClear = "DELETE FROM DataSources WHERE Identifier = :IDENTIFIER";
        public const String StoreQueryInsert = "INSERT INTO DataSources (Identifier, DisplayName, LocalDataSource, DataProviderIdentifier, Description, Status) VALUES (:IDENTIFIER, :DISPLAYNAME, :LOCALSOURCE, :PROVIDERID, :DESCRIPTION, :STATUS)";
        public const String LoadQuery = "SELECT Identifier, DisplayName, LocalDataSource, DataProviderIdentifier, Description, Status FROM DataSources WHERE Identifier = :IDENTIFIER";

        public string LocalPersistence { get; set; }

        public string Identifier { get; set; }

        public string DisplayName { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string DataProviderIdentifier { get; set; }


        public void Store(ServerDataConnection server)
        {
            //store to server
            SQLiteCommand command = server.CreateCommand();

            command.CommandText = StoreQueryClear;
            command.Parameters.AddWithValue("IDENTIFIER", Identifier);

            command.ExecuteNonQuery();

            command = server.CreateCommand();

            command.CommandText = StoreQueryInsert;
            command.Parameters.AddWithValue("IDENTIFIER", Identifier);
            command.Parameters.AddWithValue("DISPLAYNAME", DisplayName ?? "");
            command.Parameters.AddWithValue("LOCALSOURCE", LocalPersistence);
            command.Parameters.AddWithValue("PROVIDERID", DataProviderIdentifier);
            command.Parameters.AddWithValue("DESCRIPTION", Description);
            command.Parameters.AddWithValue("STATUS", Status);

            command.ExecuteNonQuery();
        }

        public static BaseDataSource Load(ServerDataConnection connection, String identifier)
        {
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = LoadQuery;
            command.Parameters.AddWithValue("IDENTIFIER", identifier);

            SQLiteDataReader reader = command.ExecuteReader();

            BaseDataSource retVal = new BaseDataSource();

            while (reader.Read())
            {
                retVal.Identifier = identifier;
                retVal.DisplayName = reader.GetString(1);
                retVal.LocalPersistence = reader.GetString(2);
                retVal.DataProviderIdentifier = reader.GetString(3);
                retVal.Description = reader.GetString(4);
                retVal.Status = reader.GetString(5);
            }

            return retVal;
        }

        public virtual void LoadItem(IEnquireDataItem dataItem)
        {
        }
    }
}
