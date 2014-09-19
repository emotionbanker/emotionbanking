using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.PersistenceModule.DataSource
{
    public class DataSourcePersistence
    {
        private DataSourceConnection _connection;

        public void CreateDatabase(String filename)
        {
            SQLiteConnection.CreateFile(filename);

            _connection = new DataSourceConnection(filename);

            _connection.OpenConnection();


            //create tables


            _connection.CloseConnection();
        }

        public void CreateItemCatalog()
        {
            SQLiteCommand command = _connection.CreateCommand();

            command.CommandText = Scripts.CreateDataSourcePersitence;
        }
    }
}
