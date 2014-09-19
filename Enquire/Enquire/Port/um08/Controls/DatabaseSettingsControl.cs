using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using MySQLDriverCS;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
    /// <summary>
    /// Summary description for DatabaseSettingsControl.
    /// </summary>
    public class DatabaseSettingsControl : UserControl
    {
        private Panel HeaderPanel;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private TextBox ServerBox;
        private Label label6;
        private TextBox DatabaseBox;
        private TextBox UserBox;
        private TextBox PasswordBox;
        private Button SelectVirtualButton;
        private ComboBox PrefixBox;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private Evaluation eval;

        public DatabaseSettingsControl(Evaluation eval)
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

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ResourceManager resources = new ResourceManager(typeof(DatabaseSettingsControl));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label5 = new Label();
            this.SelectVirtualButton = new Button();
            this.ServerBox = new TextBox();
            this.DatabaseBox = new TextBox();
            this.UserBox = new TextBox();
            this.PasswordBox = new TextBox();
            this.label6 = new Label();
            this.PrefixBox = new ComboBox();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = Color.White;
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.pictureBox1);
            this.HeaderPanel.Dock = DockStyle.Top;
            this.HeaderPanel.Location = new Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new Size(648, 80);
            this.HeaderPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(72, 16);
            this.label1.Name = "label1";
            this.label1.Size = new Size(552, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datenbankeinstellungen";
            this.label1.Click += new EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new Point(24, 190);
            this.label4.Name = "label4";
            this.label4.Size = new Size(146, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Passwort:";
            this.label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new Point(24, 160);
            this.label3.Name = "label3";
            this.label3.Size = new Size(146, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Benutzername:";
            this.label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new Size(146, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datenbank:";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new Point(24, 96);
            this.label5.Name = "label5";
            this.label5.Size = new Size(146, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Server:";
            this.label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SelectVirtualButton
            // 
            this.SelectVirtualButton.BackColor = Color.LightGray;
            this.SelectVirtualButton.FlatStyle = FlatStyle.Popup;
            this.SelectVirtualButton.Location = new Point(182, 276);
            this.SelectVirtualButton.Name = "SelectVirtualButton";
            this.SelectVirtualButton.Size = new Size(294, 32);
            this.SelectVirtualButton.TabIndex = 8;
            this.SelectVirtualButton.Text = "Nach virtuellen Datenbanken suchen....";
            this.SelectVirtualButton.Click += new EventHandler(this.SelectVirtualButton_Click);
            // 
            // ServerBox
            // 
            this.ServerBox.BorderStyle = BorderStyle.FixedSingle;
            this.ServerBox.Location = new Point(182, 98);
            this.ServerBox.Name = "ServerBox";
            this.ServerBox.Size = new Size(294, 23);
            this.ServerBox.TabIndex = 9;
            this.ServerBox.Text = "";
            this.ServerBox.TextChanged += new EventHandler(this.ServerBox_TextChanged);
            // 
            // DatabaseBox
            // 
            this.DatabaseBox.BorderStyle = BorderStyle.FixedSingle;
            this.DatabaseBox.Location = new Point(182, 130);
            this.DatabaseBox.Name = "DatabaseBox";
            this.DatabaseBox.Size = new Size(294, 23);
            this.DatabaseBox.TabIndex = 10;
            this.DatabaseBox.Text = "";
            this.DatabaseBox.TextChanged += new EventHandler(this.DatabaseBox_TextChanged);
            // 
            // UserBox
            // 
            this.UserBox.BorderStyle = BorderStyle.FixedSingle;
            this.UserBox.Location = new Point(182, 160);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new Size(294, 23);
            this.UserBox.TabIndex = 11;
            this.UserBox.Text = "";
            this.UserBox.TextChanged += new EventHandler(this.UserBox_TextChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.BorderStyle = BorderStyle.FixedSingle;
            this.PasswordBox.Location = new Point(182, 192);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new Size(294, 23);
            this.PasswordBox.TabIndex = 12;
            this.PasswordBox.Text = "";
            this.PasswordBox.TextChanged += new EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new Point(24, 244);
            this.label6.Name = "label6";
            this.label6.Size = new Size(146, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Virtuelle Datenbank:";
            this.label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PrefixBox
            // 
            this.PrefixBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PrefixBox.Location = new Point(182, 242);
            this.PrefixBox.Name = "PrefixBox";
            this.PrefixBox.Size = new Size(296, 24);
            this.PrefixBox.TabIndex = 14;
            this.PrefixBox.SelectedIndexChanged += new EventHandler(this.PrefixBox_SelectedIndexChanged);
            // 
            // DatabaseSettingsControl
            // 
            this.BackColor = Color.Gainsboro;
            this.Controls.Add(this.PrefixBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.DatabaseBox);
            this.Controls.Add(this.ServerBox);
            this.Controls.Add(this.SelectVirtualButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HeaderPanel);
            this.Font = new Font("Arial", 8F);
            this.Name = "DatabaseSettingsControl";
            this.Size = new Size(648, 368);
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void SelectVirtualButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            MySQLConnection db = new MySQLConnection(new MySQLConnectionString(ServerBox.Text, DatabaseBox.Text, UserBox.Text, PasswordBox.Text).AsString);

            try
            {
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
                MessageBox.Show("Datenbank konnte nicht geöffnet werden!\n" + ex.Message + "\n" + ex.StackTrace, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Enabled = true;
        }

        private void ServerBox_TextChanged(object sender, EventArgs e)
        {
            eval.DatabaseHost = ServerBox.Text;
        }

        private void DatabaseBox_TextChanged(object sender, EventArgs e)
        {
            eval.DatabaseName = DatabaseBox.Text;
        }

        private void UserBox_TextChanged(object sender, EventArgs e)
        {
            eval.DatabaseUser = UserBox.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            eval.DatabasePassword = PasswordBox.Text;
        }

        private void PrefixBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabasePrefix prefix = (DatabasePrefix)PrefixBox.SelectedItem;
            eval.DatabasePrefix = prefix.Prefix;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
