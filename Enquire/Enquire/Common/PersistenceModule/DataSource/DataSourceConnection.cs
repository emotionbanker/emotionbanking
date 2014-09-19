using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.PersistenceModule.DataSource
{
    public class DataSourceConnection
    {
        private readonly SQLiteConnection _connection;

        public SQLiteConnection Connection
        {
            get { return _connection; }
        }

        public DataSourceConnection(String filename)
        {
            _connection = new SQLiteConnection(String.Format("data source={0}", filename));
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            _connection.Clone();
        }

        public SQLiteCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }
    }
}
