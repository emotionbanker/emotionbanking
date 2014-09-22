using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Collections;
using MySql.Data.MySqlClient;

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
                var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
                sqlConnectionStringBuilder.Server = ServerBox.Text;
                sqlConnectionStringBuilder.Database = DatabaseBox.Text;
                sqlConnectionStringBuilder.UserID = UserBox.Text;
                sqlConnectionStringBuilder.Password = PasswordBox.Text;

                MySqlConnection db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();
                ArrayList tables = new ArrayList();

                MySqlCommand cmd = new MySqlCommand("show tables", db);
                MySqlDataReader d = cmd.ExecuteReader();

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
                MessageBox.Show("Datenbank konnte nicht geöffnet werden!\n" + ex.Message + "\n" + ex.StackTrace, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
