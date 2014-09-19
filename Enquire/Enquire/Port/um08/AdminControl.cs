using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace umfrage
{
	/// <summary>
	/// Summary description for AdminControl.
	/// </summary>
	public class AdminControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel stepPanel;
		private System.Windows.Forms.Label label1;


		public WebSurvey survey;
		private System.Windows.Forms.Panel stylePanel;
		private System.Windows.Forms.TextBox styleBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel settingsPanel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox sTitleBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sUserBox;
		private System.Windows.Forms.TextBox sPassBox;
		private System.Windows.Forms.TextBox sHostBox;
		private System.Windows.Forms.TextBox sDBBox;
		private System.Windows.Forms.TextBox sDBIDBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		public System.Windows.Forms.TextBox imgBox;
		private System.Windows.Forms.Label label03;
		private System.Windows.Forms.Panel staticsPanel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox staticsBox;
		private System.Windows.Forms.TextBox editstatic;
		private System.Windows.Forms.Button button2;
		private int status;

		public AdminControl()
		{
			InitializeComponent();

			survey = new WebSurvey();
			status = 0;

			stylePanel.Dock = DockStyle.Fill;
			settingsPanel.Dock = DockStyle.Fill;
			staticsPanel.Dock = DockStyle.Fill;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		private void HideAll()
		{
			stylePanel.Visible = false;
			settingsPanel.Visible = false;
			staticsPanel.Visible = false;

			label1.BackColor = Color.Silver;
			label2.BackColor = Color.Silver;
			label03.BackColor = Color.Silver;
		}

		public void ReDo()
		{
			//fill controls

			sTitleBox.Text = survey.TITLE;
			sHostBox.Text = survey.DB_HOST;
			sDBBox.Text = survey.DB_BASE;
			sDBIDBox.Text = survey.DB_ID;
			sUserBox.Text = survey.DB_USER;
			sPassBox.Text = survey.DB_PASS;

			styleBox.Text = survey.getCSS();

			staticsBox.Items.Clear();
			foreach (string s in survey.getStaticNames())
				staticsBox.Items.Add(s.Trim());

			//set controls
			setControls();
		}

		public void Save()
		{
			survey.TITLE = sTitleBox.Text;
			survey.DB_HOST = sHostBox.Text;
			survey.DB_BASE = sDBBox.Text;
			survey.DB_USER = sUserBox.Text;
			survey.DB_PASS = sPassBox.Text;
			survey.DB_ID   = sDBIDBox.Text;

			survey.setCSS(styleBox.Text);


		}

		public void setControls()
		{
			HideAll();

			switch (status)
			{
				case 0:
					label1.BackColor = Color.SteelBlue;
					stylePanel.Visible = true;
					break;

				case 1:
					label2.BackColor = Color.SteelBlue;
					settingsPanel.Visible = true;
					break;
				
				case 2:
					label03.BackColor = Color.SteelBlue;
					staticsPanel.Visible = true;
					break;
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.stepPanel = new System.Windows.Forms.Panel();
			this.label03 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.stylePanel = new System.Windows.Forms.Panel();
			this.styleBox = new System.Windows.Forms.TextBox();
			this.settingsPanel = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.sDBIDBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.sPassBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.sUserBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.sDBBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sHostBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.imgBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sTitleBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.staticsPanel = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.editstatic = new System.Windows.Forms.TextBox();
			this.staticsBox = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.stepPanel.SuspendLayout();
			this.stylePanel.SuspendLayout();
			this.settingsPanel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.staticsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// stepPanel
			// 
			this.stepPanel.BackColor = System.Drawing.Color.Silver;
			this.stepPanel.Controls.Add(this.label03);
			this.stepPanel.Controls.Add(this.label2);
			this.stepPanel.Controls.Add(this.label1);
			this.stepPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.stepPanel.Location = new System.Drawing.Point(0, 0);
			this.stepPanel.Name = "stepPanel";
			this.stepPanel.Size = new System.Drawing.Size(150, 736);
			this.stepPanel.TabIndex = 1;
			// 
			// label03
			// 
			this.label03.BackColor = System.Drawing.Color.Silver;
			this.label03.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label03.Font = new System.Drawing.Font("Arial", 8F);
			this.label03.Location = new System.Drawing.Point(0, 50);
			this.label03.Name = "label03";
			this.label03.Size = new System.Drawing.Size(150, 25);
			this.label03.TabIndex = 2;
			this.label03.Text = "Statische Texte";
			this.label03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label03.Click += new System.EventHandler(this.label03_Click);
			this.label03.MouseEnter += new System.EventHandler(this.label03_MouseEnter);
			this.label03.MouseLeave += new System.EventHandler(this.label03_MouseLeave);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Silver;
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label2.Font = new System.Drawing.Font("Arial", 8F);
			this.label2.Location = new System.Drawing.Point(0, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Einstellungen";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Click += new System.EventHandler(this.label2_Click);
			this.label2.MouseEnter += new System.EventHandler(this.label2_Enter);
			this.label2.MouseLeave += new System.EventHandler(this.label2_Leave);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Silver;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("Arial", 8F);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Formatierungen";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			this.label1.MouseEnter += new System.EventHandler(this.label1_Enter);
			this.label1.MouseLeave += new System.EventHandler(this.label1_Leave);
			// 
			// stylePanel
			// 
			this.stylePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.stylePanel.Controls.Add(this.styleBox);
			this.stylePanel.Location = new System.Drawing.Point(672, 618);
			this.stylePanel.Name = "stylePanel";
			this.stylePanel.Size = new System.Drawing.Size(154, 72);
			this.stylePanel.TabIndex = 2;
			// 
			// styleBox
			// 
			this.styleBox.AcceptsReturn = true;
			this.styleBox.AcceptsTab = true;
			this.styleBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.styleBox.Location = new System.Drawing.Point(0, 0);
			this.styleBox.Multiline = true;
			this.styleBox.Name = "styleBox";
			this.styleBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.styleBox.Size = new System.Drawing.Size(152, 70);
			this.styleBox.TabIndex = 0;
			this.styleBox.Text = "";
			// 
			// settingsPanel
			// 
			this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.settingsPanel.Controls.Add(this.groupBox2);
			this.settingsPanel.Controls.Add(this.groupBox1);
			this.settingsPanel.Location = new System.Drawing.Point(166, 176);
			this.settingsPanel.Name = "settingsPanel";
			this.settingsPanel.Size = new System.Drawing.Size(476, 516);
			this.settingsPanel.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.sDBIDBox);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.sPassBox);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.sUserBox);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.sDBBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.sHostBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(18, 150);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(580, 218);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Datenbankeinstellungen";
			// 
			// sDBIDBox
			// 
			this.sDBIDBox.Location = new System.Drawing.Point(210, 156);
			this.sDBIDBox.Name = "sDBIDBox";
			this.sDBIDBox.Size = new System.Drawing.Size(270, 23);
			this.sDBIDBox.TabIndex = 11;
			this.sDBIDBox.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 146);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(180, 50);
			this.label8.TabIndex = 10;
			this.label8.Text = "Datenbankprefix (Simulierte Datenbank, Keine Leer oder Sonderzeichen):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sPassBox
			// 
			this.sPassBox.Location = new System.Drawing.Point(210, 116);
			this.sPassBox.Name = "sPassBox";
			this.sPassBox.PasswordChar = '*';
			this.sPassBox.Size = new System.Drawing.Size(270, 23);
			this.sPassBox.TabIndex = 9;
			this.sPassBox.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(180, 24);
			this.label7.TabIndex = 8;
			this.label7.Text = "Passwort:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sUserBox
			// 
			this.sUserBox.Location = new System.Drawing.Point(210, 84);
			this.sUserBox.Name = "sUserBox";
			this.sUserBox.Size = new System.Drawing.Size(270, 23);
			this.sUserBox.TabIndex = 7;
			this.sUserBox.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(180, 24);
			this.label6.TabIndex = 6;
			this.label6.Text = "Benutzername:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sDBBox
			// 
			this.sDBBox.Location = new System.Drawing.Point(210, 54);
			this.sDBBox.Name = "sDBBox";
			this.sDBBox.Size = new System.Drawing.Size(270, 23);
			this.sDBBox.TabIndex = 5;
			this.sDBBox.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(180, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "Datenbankname:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sHostBox
			// 
			this.sHostBox.Location = new System.Drawing.Point(210, 22);
			this.sHostBox.Name = "sHostBox";
			this.sHostBox.Size = new System.Drawing.Size(270, 23);
			this.sHostBox.TabIndex = 3;
			this.sHostBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(180, 24);
			this.label4.TabIndex = 2;
			this.label4.Text = "Host (Server):";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.imgBox);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.sTitleBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(18, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(580, 128);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Allgemeine Einstellungen";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(402, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(82, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "auswählen";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// imgBox
			// 
			this.imgBox.Location = new System.Drawing.Point(214, 66);
			this.imgBox.Name = "imgBox";
			this.imgBox.Size = new System.Drawing.Size(180, 23);
			this.imgBox.TabIndex = 3;
			this.imgBox.Text = "unverändert";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(180, 24);
			this.label9.TabIndex = 2;
			this.label9.Text = "Titelbild:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sTitleBox
			// 
			this.sTitleBox.Location = new System.Drawing.Point(214, 32);
			this.sTitleBox.Name = "sTitleBox";
			this.sTitleBox.Size = new System.Drawing.Size(270, 23);
			this.sTitleBox.TabIndex = 1;
			this.sTitleBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(180, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "Titel:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// staticsPanel
			// 
			this.staticsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.staticsPanel.Controls.Add(this.button2);
			this.staticsPanel.Controls.Add(this.editstatic);
			this.staticsPanel.Controls.Add(this.staticsBox);
			this.staticsPanel.Controls.Add(this.label10);
			this.staticsPanel.Location = new System.Drawing.Point(194, 20);
			this.staticsPanel.Name = "staticsPanel";
			this.staticsPanel.Size = new System.Drawing.Size(166, 144);
			this.staticsPanel.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.Control;
			this.button2.Location = new System.Drawing.Point(14, 404);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(170, 36);
			this.button2.TabIndex = 3;
			this.button2.Text = "speichern";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// editstatic
			// 
			this.editstatic.AcceptsReturn = true;
			this.editstatic.AcceptsTab = true;
			this.editstatic.Location = new System.Drawing.Point(12, 58);
			this.editstatic.Multiline = true;
			this.editstatic.Name = "editstatic";
			this.editstatic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.editstatic.Size = new System.Drawing.Size(546, 338);
			this.editstatic.TabIndex = 2;
			this.editstatic.Text = "";
			// 
			// staticsBox
			// 
			this.staticsBox.Location = new System.Drawing.Point(94, 14);
			this.staticsBox.Name = "staticsBox";
			this.staticsBox.Size = new System.Drawing.Size(276, 24);
			this.staticsBox.TabIndex = 1;
			this.staticsBox.SelectedIndexChanged += new System.EventHandler(this.staticsBox_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(14, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(76, 20);
			this.label10.TabIndex = 0;
			this.label10.Text = "Auswahl:";
			// 
			// AdminControl
			// 
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.Controls.Add(this.staticsPanel);
			this.Controls.Add(this.settingsPanel);
			this.Controls.Add(this.stylePanel);
			this.Controls.Add(this.stepPanel);
			this.Font = new System.Drawing.Font("Arial", 8F);
			this.Name = "AdminControl";
			this.Size = new System.Drawing.Size(870, 736);
			this.stepPanel.ResumeLayout(false);
			this.stylePanel.ResumeLayout(false);
			this.settingsPanel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.staticsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void label1_Enter(object sender, System.EventArgs e)
		{
			label1.BackColor = Color.SteelBlue;
		}

		private void label1_Leave(object sender, System.EventArgs e)
		{
			if (status != 0)
				label1.BackColor = Color.Silver;
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			status = 0;
			setControls();
		}

		private void label2_Enter(object sender, System.EventArgs e)
		{
			label2.BackColor = Color.SteelBlue;
		}

		private void label2_Leave(object sender, System.EventArgs e)
		{
			if (status != 1)
				label2.BackColor = Color.Silver;
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			status = 1;
			setControls();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				imgBox.Text = openFileDialog.FileName;
			}
		}

		private void label03_MouseEnter(object sender, System.EventArgs e)
		{
			label03.BackColor = Color.SteelBlue;
		}

		private void label03_MouseLeave(object sender, System.EventArgs e)
		{
			if (status != 2)
				label03.BackColor = Color.Silver;
		}

		private void label03_Click(object sender, System.EventArgs e)
		{
			status = 2;
			setControls();
		}

		private void staticsBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.editstatic.Text = string.Empty;
			this.editstatic.Text = survey.getStaticAsString((string)staticsBox.SelectedItem);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string it;
			if (staticsBox.SelectedItem == null)
				it = staticsBox.Text;
			else
				it = (string)staticsBox.SelectedItem;
			survey.saveStatic(it, editstatic.Text);

			try
			{
				staticsBox.Items.Clear();
				foreach (string s in survey.getStaticNames())
					staticsBox.Items.Add(s.Trim());
			}
			catch{}
		}

	}
}
