using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Compucare.Enquire.Legacy.Umfrage2Lib
{
    public class Datenbank
    {
        public MySqlConnection db;

        public Datenbank()
        {

        }

        public MySqlConnection openDatabase()
        {
            var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            sqlConnectionStringBuilder.Server = "95.129.200.5";
            sqlConnectionStringBuilder.Database = "bankdesje_db";
            sqlConnectionStringBuilder.UserID = "bankdesje_sql";
            sqlConnectionStringBuilder.Password = "cNcPjCYFzzKJ9";

            db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);
            //db = new MySQLConnection(new MySQLConnectionString("95.129.200.10", "bdj_db", "banksql", "ma10R58z").AsString);
            return db;
        }

        public void closeDatabase()
        {
            db.Close();
        }
      
    }
}
