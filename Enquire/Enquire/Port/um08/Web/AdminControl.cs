using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Web
{
	/// <summary>
	/// Summary description for AdminControl.
	/// </summary>
	public class AdminControl : UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private Panel stepPanel;


		public WebSurvey survey;
		private Panel stylePanel;
		private TextBox styleBox;
		private Panel settingsPanel;
		private GroupBox groupBox1;
		private Label label3;
		private TextBox sTitleBox;
		private GroupBox groupBox2;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private TextBox sUserBox;
		private TextBox sPassBox;
		private TextBox sHostBox;
		private TextBox sDBBox;
		private TextBox sDBIDBox;
		private Label label8;
		private Label label9;
		private Button button1;
		private OpenFileDialog openFileDialog;
		public TextBox imgBox;
		private Panel staticsPanel;
		private Label label10;
		private ComboBox staticsBox;
		private TextBox editstatic;
		private Button button2;
		private Button SettingsButton;
		private Button button3;
		private Button button4;
		private Button QuitButton;
		private int status;
		private PictureBox pictureBox;

		private Admin a;

		public AdminControl(Admin a)
		{
			this.a = a;
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

			pictureBox.Image = survey.GetImage();

			staticsBox.Items.Clear();
			//foreach (string s in survey.getStaticNames())
			//	staticsBox.Items.Add(s.Trim());

			survey.LoadStatics();

			foreach (Static s in survey.Statics)
				staticsBox.Items.Add(s);

			//set controls
			setControls();
		}

		public void Save()
		{
			try
			{
				survey.TITLE = sTitleBox.Text;
				survey.DB_HOST = sHostBox.Text;
				survey.DB_BASE = sDBBox.Text;
				survey.DB_USER = sUserBox.Text;
				survey.DB_PASS = sPassBox.Text;
				survey.DB_ID   = sDBIDBox.Text;

				survey.setCSS(styleBox.Text);

				if (!imgBox.Text.Equals("unverändert"))
					survey.SaveImage(imgBox.Text);

				survey.SaveData();
			}
			catch
			{
				MessageBox.Show("Speicherung fehlgeschlagen. Bitte versuchen Sie es erneut", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void setControls()
		{
			HideAll();

			switch (status)
			{
				case 0:
					stylePanel.Visible = true;
					break;

				case 1:
					settingsPanel.Visible = true;
					break;
				
				case 2:
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
			ResourceManager resources = new ResourceManager(typeof(AdminControl));
			this.stepPanel = new Panel();
			this.stylePanel = new Panel();
			this.styleBox = new TextBox();
			this.settingsPanel = new Panel();
			this.groupBox2 = new GroupBox();
			this.sDBIDBox = new TextBox();
			this.label8 = new Label();
			this.sPassBox = new TextBox();
			this.label7 = new Label();
			this.sUserBox = new TextBox();
			this.label6 = new Label();
			this.sDBBox = new TextBox();
			this.label5 = new Label();
			this.sHostBox = new TextBox();
			this.label4 = new Label();
			this.groupBox1 = new GroupBox();
			this.button1 = new Button();
			this.imgBox = new TextBox();
			this.label9 = new Label();
			this.sTitleBox = new TextBox();
			this.label3 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.staticsPanel = new Panel();
			this.button2 = new Button();
			this.editstatic = new TextBox();
			this.staticsBox = new ComboBox();
			this.label10 = new Label();
			this.SettingsButton = new Button();
			this.button3 = new Button();
			this.button4 = new Button();
			this.QuitButton = new Button();
			this.pictureBox = new PictureBox();
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
			this.stepPanel.BackColor = Color.White;
			this.stepPanel.Controls.Add(this.QuitButton);
			this.stepPanel.Controls.Add(this.button4);
			this.stepPanel.Controls.Add(this.button3);
			this.stepPanel.Controls.Add(this.SettingsButton);
			this.stepPanel.Controls.Add(this.button2);
			this.stepPanel.Dock = DockStyle.Left;
			this.stepPanel.Location = new Point(0, 0);
			this.stepPanel.Name = "stepPanel";
			this.stepPanel.Size = new Size(162, 736);
			this.stepPanel.TabIndex = 1;
			// 
			// stylePanel
			// 
			this.stylePanel.BorderStyle = BorderStyle.FixedSingle;
			this.stylePanel.Controls.Add(this.styleBox);
			this.stylePanel.Location = new Point(740, 82);
			this.stylePanel.Name = "stylePanel";
			this.stylePanel.Size = new Size(114, 80);
			this.stylePanel.TabIndex = 2;
			// 
			// styleBox
			// 
			this.styleBox.AcceptsReturn = true;
			this.styleBox.AcceptsTab = true;
			this.styleBox.Dock = DockStyle.Fill;
			this.styleBox.Location = new Point(0, 0);
			this.styleBox.Multiline = true;
			this.styleBox.Name = "styleBox";
			this.styleBox.ScrollBars = ScrollBars.Both;
			this.styleBox.Size = new Size(112, 78);
			this.styleBox.TabIndex = 0;
			this.styleBox.Text = "";
			// 
			// settingsPanel
			// 
			this.settingsPanel.BorderStyle = BorderStyle.FixedSingle;
			this.settingsPanel.Controls.Add(this.groupBox2);
			this.settingsPanel.Controls.Add(this.groupBox1);
			this.settingsPanel.Location = new Point(206, 432);
			this.settingsPanel.Name = "settingsPanel";
			this.settingsPanel.Size = new Size(306, 126);
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
			this.groupBox2.Location = new Point(18, 222);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(580, 218);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Datenbankeinstellungen";
			// 
			// sDBIDBox
			// 
			this.sDBIDBox.BorderStyle = BorderStyle.FixedSingle;
			this.sDBIDBox.Location = new Point(210, 156);
			this.sDBIDBox.Name = "sDBIDBox";
			this.sDBIDBox.Size = new Size(270, 23);
			this.sDBIDBox.TabIndex = 11;
			this.sDBIDBox.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new Point(12, 146);
			this.label8.Name = "label8";
			this.label8.Size = new Size(180, 50);
			this.label8.TabIndex = 10;
			this.label8.Text = "Datenbankprefix (Simulierte Datenbank, Keine Leer oder Sonderzeichen):";
			this.label8.TextAlign = ContentAlignment.TopRight;
			// 
			// sPassBox
			// 
			this.sPassBox.BorderStyle = BorderStyle.FixedSingle;
			this.sPassBox.Location = new Point(210, 116);
			this.sPassBox.Name = "sPassBox";
			this.sPassBox.PasswordChar = '*';
			this.sPassBox.Size = new Size(270, 23);
			this.sPassBox.TabIndex = 9;
			this.sPassBox.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new Point(12, 120);
			this.label7.Name = "label7";
			this.label7.Size = new Size(180, 24);
			this.label7.TabIndex = 8;
			this.label7.Text = "Passwort:";
			this.label7.TextAlign = ContentAlignment.TopRight;
			// 
			// sUserBox
			// 
			this.sUserBox.BorderStyle = BorderStyle.FixedSingle;
			this.sUserBox.Location = new Point(210, 84);
			this.sUserBox.Name = "sUserBox";
			this.sUserBox.Size = new Size(270, 23);
			this.sUserBox.TabIndex = 7;
			this.sUserBox.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new Point(12, 88);
			this.label6.Name = "label6";
			this.label6.Size = new Size(180, 24);
			this.label6.TabIndex = 6;
			this.label6.Text = "Benutzername:";
			this.label6.TextAlign = ContentAlignment.TopRight;
			// 
			// sDBBox
			// 
			this.sDBBox.BorderStyle = BorderStyle.FixedSingle;
			this.sDBBox.Location = new Point(210, 54);
			this.sDBBox.Name = "sDBBox";
			this.sDBBox.Size = new Size(270, 23);
			this.sDBBox.TabIndex = 5;
			this.sDBBox.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new Point(12, 58);
			this.label5.Name = "label5";
			this.label5.Size = new Size(180, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "Datenbankname:";
			this.label5.TextAlign = ContentAlignment.TopRight;
			// 
			// sHostBox
			// 
			this.sHostBox.BorderStyle = BorderStyle.FixedSingle;
			this.sHostBox.Location = new Point(210, 22);
			this.sHostBox.Name = "sHostBox";
			this.sHostBox.Size = new Size(270, 23);
			this.sHostBox.TabIndex = 3;
			this.sHostBox.Text = "";
			this.sHostBox.TextChanged += new EventHandler(this.sHostBox_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new Point(12, 26);
			this.label4.Name = "label4";
			this.label4.Size = new Size(180, 24);
			this.label4.TabIndex = 2;
			this.label4.Text = "Host (Server):";
			this.label4.TextAlign = ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.imgBox);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.sTitleBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new Point(18, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(580, 198);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Allgemeine Einstellungen";
			// 
			// button1
			// 
			this.button1.BackColor = Color.LightGray;
			this.button1.FlatStyle = FlatStyle.Popup;
			this.button1.Location = new Point(402, 66);
			this.button1.Name = "button1";
			this.button1.Size = new Size(82, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "auswählen";
			this.button1.Click += new EventHandler(this.button1_Click);
			// 
			// imgBox
			// 
			this.imgBox.BorderStyle = BorderStyle.FixedSingle;
			this.imgBox.Location = new Point(214, 66);
			this.imgBox.Name = "imgBox";
			this.imgBox.Size = new Size(180, 23);
			this.imgBox.TabIndex = 3;
			this.imgBox.Text = "unverändert";
			// 
			// label9
			// 
			this.label9.Location = new Point(16, 70);
			this.label9.Name = "label9";
			this.label9.Size = new Size(180, 24);
			this.label9.TabIndex = 2;
			this.label9.Text = "Titelbild:";
			this.label9.TextAlign = ContentAlignment.TopRight;
			// 
			// sTitleBox
			// 
			this.sTitleBox.BorderStyle = BorderStyle.FixedSingle;
			this.sTitleBox.Location = new Point(214, 32);
			this.sTitleBox.Name = "sTitleBox";
			this.sTitleBox.Size = new Size(270, 23);
			this.sTitleBox.TabIndex = 1;
			this.sTitleBox.Text = "";
			this.sTitleBox.TextChanged += new EventHandler(this.sTitleBox_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new Point(16, 36);
			this.label3.Name = "label3";
			this.label3.Size = new Size(180, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "Titel:";
			this.label3.TextAlign = ContentAlignment.TopRight;
			// 
			// staticsPanel
			// 
			this.staticsPanel.BorderStyle = BorderStyle.FixedSingle;
			this.staticsPanel.Controls.Add(this.editstatic);
			this.staticsPanel.Controls.Add(this.staticsBox);
			this.staticsPanel.Controls.Add(this.label10);
			this.staticsPanel.Location = new Point(192, 16);
			this.staticsPanel.Name = "staticsPanel";
			this.staticsPanel.Size = new Size(570, 396);
			this.staticsPanel.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.BackColor = Color.LightGray;
			this.button2.FlatStyle = FlatStyle.Popup;
			this.button2.Location = new Point(10, 156);
			this.button2.Name = "button2";
			this.button2.Size = new Size(138, 32);
			this.button2.TabIndex = 3;
			this.button2.Text = "Speichern";
			this.button2.Click += new EventHandler(this.button2_Click);
			// 
			// editstatic
			// 
			this.editstatic.AcceptsReturn = true;
			this.editstatic.AcceptsTab = true;
			this.editstatic.Location = new Point(12, 58);
			this.editstatic.Multiline = true;
			this.editstatic.Name = "editstatic";
			this.editstatic.ScrollBars = ScrollBars.Both;
			this.editstatic.Size = new Size(546, 338);
			this.editstatic.TabIndex = 2;
			this.editstatic.Text = "";
			this.editstatic.TextChanged += new EventHandler(this.editstatic_TextChanged);
			// 
			// staticsBox
			// 
			this.staticsBox.Location = new Point(94, 14);
			this.staticsBox.Name = "staticsBox";
			this.staticsBox.Size = new Size(276, 24);
			this.staticsBox.TabIndex = 1;
			this.staticsBox.SelectedIndexChanged += new EventHandler(this.staticsBox_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new Point(14, 18);
			this.label10.Name = "label10";
			this.label10.Size = new Size(76, 20);
			this.label10.TabIndex = 0;
			this.label10.Text = "Auswahl:";
			// 
			// SettingsButton
			// 
			this.SettingsButton.BackColor = Color.LightGray;
			this.SettingsButton.FlatStyle = FlatStyle.Popup;
			this.SettingsButton.Image = ((Image)(resources.GetObject("SettingsButton.Image")));
			this.SettingsButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.SettingsButton.Location = new Point(10, 6);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new Size(138, 32);
			this.SettingsButton.TabIndex = 3;
			this.SettingsButton.Text = "Formatierungen";
			this.SettingsButton.Click += new EventHandler(this.SettingsButton_Click);
			// 
			// button3
			// 
			this.button3.BackColor = Color.LightGray;
			this.button3.FlatStyle = FlatStyle.Popup;
			this.button3.Image = ((Image)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = ContentAlignment.MiddleLeft;
			this.button3.Location = new Point(10, 48);
			this.button3.Name = "button3";
			this.button3.Size = new Size(138, 32);
			this.button3.TabIndex = 4;
			this.button3.Text = "Einstellungen";
			this.button3.Click += new EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.BackColor = Color.LightGray;
			this.button4.FlatStyle = FlatStyle.Popup;
			this.button4.Image = ((Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = ContentAlignment.MiddleLeft;
			this.button4.Location = new Point(10, 88);
			this.button4.Name = "button4";
			this.button4.Size = new Size(138, 32);
			this.button4.TabIndex = 5;
			this.button4.Text = "Texte";
			this.button4.Click += new EventHandler(this.button4_Click);
			// 
			// QuitButton
			// 
			this.QuitButton.BackColor = Color.LightGray;
			this.QuitButton.FlatStyle = FlatStyle.Popup;
			this.QuitButton.Image = ((Image)(resources.GetObject("QuitButton.Image")));
			this.QuitButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.QuitButton.Location = new Point(10, 196);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new Size(138, 32);
			this.QuitButton.TabIndex = 6;
			this.QuitButton.Text = "Schliessen";
			this.QuitButton.Click += new EventHandler(this.QuitButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.BorderStyle = BorderStyle.FixedSingle;
			this.pictureBox.Location = new Point(214, 94);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new Size(270, 92);
			this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 5;
			this.pictureBox.TabStop = false;
			// 
			// AdminControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.staticsPanel);
			this.Controls.Add(this.settingsPanel);
			this.Controls.Add(this.stylePanel);
			this.Controls.Add(this.stepPanel);
			this.Font = new Font("Arial", 8F);
			this.Name = "AdminControl";
			this.Size = new Size(870, 736);
			this.stepPanel.ResumeLayout(false);
			this.stylePanel.ResumeLayout(false);
			this.settingsPanel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.staticsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				imgBox.Text = openFileDialog.FileName;
				pictureBox.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		private void staticsBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//this.editstatic.Text = string.Empty;
			//this.editstatic.Text = survey.getStaticAsString((string)staticsBox.SelectedItem);
			if (staticsBox.SelectedItem != null)
				editstatic.Text = ((Static)staticsBox.SelectedItem).Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Save();
			survey.saveStatics();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			status = 0;
			setControls();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			status = 1;
			setControls();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			status = 2;
			setControls();
		}

		private void sTitleBox_TextChanged(object sender, EventArgs e)
		{
		
		}

		private void sHostBox_TextChanged(object sender, EventArgs e)
		{
		
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			a.Close();
		}

		private void editstatic_TextChanged(object sender, EventArgs e)
		{
			if (staticsBox.SelectedItem != null)
				((Static)staticsBox.SelectedItem).Text = editstatic.Text;
		}

	}
}
