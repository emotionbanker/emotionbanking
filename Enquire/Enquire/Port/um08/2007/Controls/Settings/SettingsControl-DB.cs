using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using MySQLDriverCS;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_DB : UserControl
    {
        private Evaluation eval;

        public SettingsControl_DB(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            ServerBox.Text = eval.DatabaseHost;
            DatabaseBox.Text = eval.DatabaseName;
            UserBox.Text = eval.DatabaseUser;
            PasswordBox.Text = eval.DatabasePassword;

            DatabasePrefix prefix = new DatabasePrefix(eval.DatabasePrefix);
            PrefixBox.Items.Add(prefix);
            PrefixBox.SelectedItem = prefix;
        }

        private void SelectVirtualButton_Click(object sender, System.EventArgs e)
        {
            this.Enabled = false;
            try
            {
                MySQLConnection db = new MySQLConnection(new MySQLConnectionString(ServerBox.Text, DatabaseBox.Text, UserBox.Text, PasswordBox.Text).AsString);
                db.Open();
                ArrayList tables = new ArrayList();

                MySQLCommand cmd = new MySQLCommand("show tables", db);
                MySQLDataReader d = cmd.ExecuteReaderEx();

                while (d.Read())
                {
                    tables.Add(d.GetString(0));
                }

                ArrayList pf = new ArrayList();
                foreach (string table in tables)
                {
                    if (table.IndexOf("bank") != -1)
                    {
                        string s = table.Substring(0, table.IndexOf("bank"));
                        if (s.Length > 0)
                            pf.Add(s);
                    }
                }

                PrefixBox.Items.Clear();

                foreach (string s in pf)
                    PrefixBox.Items.Add(new DatabasePrefix(s));

                DatabasePrefix none = new DatabasePrefix();
                PrefixBox.Items.Add(none);
                PrefixBox.SelectedItem = none;

                db.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbank konnte nicht ge�ffnet werden!\n" + ex.Message + "\n" + ex.StackTrace, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Enabled = true;
        }

        private void ServerBox_TextChanged(object sender, System.EventArgs e)
        {
            eval.DatabaseHost = ServerBox.Text;
        }

        private void DatabaseBox_TextChanged(object sender, System.EventArgs e)
        {
            eval.DatabaseName = DatabaseBox.Text;
        }

        private void UserBox_TextChanged(object sender, System.EventArgs e)
        {
            eval.DatabaseUser = UserBox.Text;
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            eval.DatabasePassword = PasswordBox.Text;
        }

        private void PrefixBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DatabasePrefix prefix = (DatabasePrefix)PrefixBox.SelectedItem;
            eval.DatabasePrefix = prefix.Prefix;
        }

        private void UserBox_TextChanged_1(object sender, EventArgs e)
        {
            eval.DatabaseUser = UserBox.Text;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            eval.DatabasePassword = PasswordBox.Text;
        }

        private void PrefixBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DatabasePrefix prefix = (DatabasePrefix)PrefixBox.SelectedItem;
            eval.DatabasePrefix = prefix.Prefix;
        }
    }
}
