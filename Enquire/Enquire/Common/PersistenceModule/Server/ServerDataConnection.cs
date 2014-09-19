using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Compucare.Enquire.Common.PersistenceModule.Server
{
    public class ServerDataConnection
    {
        private const string ServerDatasource = "Persistence/EnquireServer";
        private readonly SQLiteConnection _connection;
        

        public SQLiteConnection Connection
        {
            get { return _connection; }
        }

        public ServerDataConnection()
        {
            bool create = false;
            if (!File.Exists(ServerDatasource))
            {
                if (!Directory.Exists(ServerDatasource))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ServerDatasource));
                }
                SQLiteConnection.CreateFile(ServerDatasource);
                create = true;
            }

            _connection = new SQLiteConnection(String.Format("data source={0}", ServerDatasource));

            if (create)
            {
                OpenConnection();
                SQLiteCommand command = _connection.CreateCommand();
                command.CommandText = Scripts.CreateDataSourceServer;
                command.ExecuteNonQuery();
            }
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public SQLiteCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

         ~ServerDataConnection()
         {
             _connection.Close();
         }
    }
}
