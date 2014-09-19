using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySQLDriverCS;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.Umfrage2Lib
{
    public class Datenbank
    {
        public MySQLConnection db;

        public Datenbank()
        {

        }

        public MySQLConnection openDatabase()
        {
            db = new MySQLConnection(new MySQLConnectionString("95.129.200.5", "bankdesje_db", "bankdesje_sql", "cNcPjCYFzzKJ9").AsString);
            //db = new MySQLConnection(new MySQLConnectionString("95.129.200.10", "bdj_db", "banksql", "ma10R58z").AsString);
            return db;
        }

        public void closeDatabase()
        {
            db.Close();
        }
      
    }
}
