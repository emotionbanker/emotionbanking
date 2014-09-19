using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace umfrage
{
	/// <summary>
	/// Summary description for CreateSurveyForm.
	/// </summary>
	public class CreateSurveyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox sPassBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sUserBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox sHostBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox sDirBox;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.createButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.sPassBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.sUserBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.sDirBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sHostBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
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
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(532, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "FTP Einstellungen";
			// 
			// createButton
			// 
			this.createButton.BackColor = System.Drawing.SystemColors.Control;
			this.createButton.Location = new System.Drawing.Point(374, 202);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(170, 34);
			this.createButton.TabIndex = 1;
			this.createButton.Text = "Weiter";
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
			this.cancelButton.Location = new System.Drawing.Point(196, 202);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(170, 34);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Abbrechen";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// sPassBox
			// 
			this.sPassBox.Location = new System.Drawing.Point(218, 126);
			this.sPassBox.Name = "sPassBox";
			this.sPassBox.PasswordChar = '*';
			this.sPassBox.Size = new System.Drawing.Size(270, 23);
			this.sPassBox.TabIndex = 17;
			this.sPassBox.Text = "pl56rf22";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(20, 130);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(180, 24);
			this.label7.TabIndex = 16;
			this.label7.Text = "Passwort:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sUserBox
			// 
			this.sUserBox.Location = new System.Drawing.Point(218, 94);
			this.sUserBox.Name = "sUserBox";
			this.sUserBox.Size = new System.Drawing.Size(270, 23);
			this.sUserBox.TabIndex = 15;
			this.sUserBox.Text = "bankdj";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(180, 24);
			this.label6.TabIndex = 14;
			this.label6.Text = "Benutzername:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sDirBox
			// 
			this.sDirBox.Location = new System.Drawing.Point(218, 64);
			this.sDirBox.Name = "sDirBox";
			this.sDirBox.Size = new System.Drawing.Size(270, 23);
			this.sDirBox.TabIndex = 13;
			this.sDirBox.Text = "www.bankdesjahres.at/htdocs/test";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(180, 24);
			this.label5.TabIndex = 12;
			this.label5.Text = "Ordner:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sHostBox
			// 
			this.sHostBox.Location = new System.Drawing.Point(218, 32);
			this.sHostBox.Name = "sHostBox";
			this.sHostBox.Size = new System.Drawing.Size(270, 23);
			this.sHostBox.TabIndex = 11;
			this.sHostBox.Text = "www.bankdesjahres.at";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(180, 24);
			this.label4.TabIndex = 10;
			this.label4.Text = "FTP Server:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CreateSurveyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(560, 260);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Arial", 8F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreateSurveyForm";
			this.Text = "Umfragedaten";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void createButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			survey = new WebSurvey(this.sHostBox.Text, this.sDirBox.Text, this.sUserBox.Text, this.sPassBox.Text);
			//survey.Create();
		}
	}
}
