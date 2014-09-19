using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Compucare.Enquire.Common.PersistenceModule.Server.UserManagement
{
    public class UserManagementProvider
    {
        private ServerDataConnection _server;

        public UserManagementProvider(ServerDataConnection server)
        {
            _server = server;
        }

        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return BitConverter.ToString(result);
        } 

        public bool Authenticate(String username, String password)
        {
            return (from user in GetUserList() where user.Item1 == username select user.Item2 == GetMD5Hash(password)).FirstOrDefault();
        }

        public void AddUser(String username, String password)
        {
            SQLiteCommand cmd = _server.CreateCommand();

            String pwHash = GetMD5Hash(password);
            cmd.CommandText =
                String.Format(@"insert into Users 
                   (Username, Password)
                   values ('{0}', '{1}')",
                             username, pwHash);

            cmd.ExecuteNonQuery();
        }

        public bool UserExists(String username)
        {
            return GetUserList().Any(user => user.Item1 == username);
        }

        public void RemoveUser(String username)
        {
            SQLiteCommand cmd = _server.CreateCommand();

            cmd.CommandText =
                String.Format(@"delete from Users where username = '{0}'",
                             username);

            cmd.ExecuteNonQuery();
        }

        public List<Tuple<String,String>> GetUserList()
        {
            SQLiteCommand cmd = _server.CreateCommand();

            cmd.CommandText =
                String.Format(@"select Username, Password from Users;");

            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Tuple<String,String>> retVal = new List<Tuple<String,String>>();

            while (reader.Read())
            {
                retVal.Add(new Tuple<string, string>(reader.GetString(0), reader.GetString(1))); 
            }

            return retVal;
        }
    }
}
