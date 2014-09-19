using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Web
{
	/// <summary>
	/// Summary description for CreateSurveyForm.
	/// </summary>
	public class CreateSurveyForm : Form
	{
		private GroupBox groupBox1;
		private Button createButton;
		private Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private TextBox sPassBox;
		private Label label7;
		private TextBox sUserBox;
		private Label label6;
		private Label label5;
		private TextBox sHostBox;
		private Label label4;
		private TextBox sDirBox;

		private WebSurvey survey;

		public CreateSurveyForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			survey = new WebSurvey();
		}

		public WebSurvey getSurvey()
		{
			return survey;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.sPassBox = new TextBox();
			this.label7 = new Label();
			this.sUserBox = new TextBox();
			this.label6 = new Label();
			this.sDirBox = new TextBox();
			this.label5 = new Label();
			this.sHostBox = new TextBox();
			this.label4 = new Label();
			this.createButton = new Button();
			this.cancelButton = new Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sPassBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.sUserBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.sDirBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.sHostBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(532, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "FTP Einstellungen";
			// 
			// sPassBox
			// 
			this.sPassBox.BorderStyle = BorderStyle.FixedSingle;
			this.sPassBox.Location = new Point(218, 126);
			this.sPassBox.Name = "sPassBox";
			this.sPassBox.PasswordChar = '*';
			this.sPassBox.Size = new Size(270, 23);
			this.sPassBox.TabIndex = 17;
			this.sPassBox.Text = "pl56rf22";
			// 
			// label7
			// 
			this.label7.Location = new Point(20, 130);
			this.label7.Name = "label7";
			this.label7.Size = new Size(180, 24);
			this.label7.TabIndex = 16;
			this.label7.Text = "Passwort:";
			this.label7.TextAlign = ContentAlignment.TopRight;
			// 
			// sUserBox
			// 
			this.sUserBox.BorderStyle = BorderStyle.FixedSingle;
			this.sUserBox.Location = new Point(218, 94);
			this.sUserBox.Name = "sUserBox";
			this.sUserBox.Size = new Size(270, 23);
			this.sUserBox.TabIndex = 15;
			this.sUserBox.Text = "bankdj";
			// 
			// label6
			// 
			this.label6.Location = new Point(20, 98);
			this.label6.Name = "label6";
			this.label6.Size = new Size(180, 24);
			this.label6.TabIndex = 14;
			this.label6.Text = "Benutzername:";
			this.label6.TextAlign = ContentAlignment.TopRight;
			// 
			// sDirBox
			// 
			this.sDirBox.BorderStyle = BorderStyle.FixedSingle;
			this.sDirBox.Location = new Point(218, 64);
			this.sDirBox.Name = "sDirBox";
			this.sDirBox.Size = new Size(270, 23);
			this.sDirBox.TabIndex = 13;
			this.sDirBox.Text = "www.bankdesjahres.at/htdocs/test";
			// 
			// label5
			// 
			this.label5.Location = new Point(20, 68);
			this.label5.Name = "label5";
			this.label5.Size = new Size(180, 24);
			this.label5.TabIndex = 12;
			this.label5.Text = "Ordner:";
			this.label5.TextAlign = ContentAlignment.TopRight;
			// 
			// sHostBox
			// 
			this.sHostBox.BorderStyle = BorderStyle.FixedSingle;
			this.sHostBox.Location = new Point(218, 32);
			this.sHostBox.Name = "sHostBox";
			this.sHostBox.Size = new Size(270, 23);
			this.sHostBox.TabIndex = 11;
			this.sHostBox.Text = "www.bankdesjahres.at";
			// 
			// label4
			// 
			this.label4.Location = new Point(20, 36);
			this.label4.Name = "label4";
			this.label4.Size = new Size(180, 24);
			this.label4.TabIndex = 10;
			this.label4.Text = "FTP Server:";
			this.label4.TextAlign = ContentAlignment.TopRight;
			// 
			// createButton
			// 
			this.createButton.BackColor = Color.LightGray;
			this.createButton.Cursor = Cursors.Default;
			this.createButton.FlatStyle = FlatStyle.Popup;
			this.createButton.Location = new Point(374, 202);
			this.createButton.Name = "createButton";
			this.createButton.Size = new Size(170, 34);
			this.createButton.TabIndex = 1;
			this.createButton.Text = "Weiter";
			this.createButton.Click += new EventHandler(this.createButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.BackColor = Color.LightGray;
			this.cancelButton.Cursor = Cursors.Default;
			this.cancelButton.FlatStyle = FlatStyle.Popup;
			this.cancelButton.Location = new Point(196, 202);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(170, 34);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Abbrechen";
			this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
			// 
			// CreateSurveyForm
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(560, 250);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.groupBox1);
			this.Font = new Font("Arial", 8F);
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = "CreateSurveyForm";
			this.Text = "Internetumfrage";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			survey = new WebSurvey(this.sHostBox.Text, this.sDirBox.Text, this.sUserBox.Text, this.sPassBox.Text);
			//survey.Create();
		}
	}
}
