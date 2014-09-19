using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for EvaluationControl.
	/// </summary>
	public class EvaluationControl : UserControl
	{
		private Panel NaviagationPanel;
		private Button DatabaseButton;
		private Button button3;
		private Button button4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private DatabaseSettingsControl DatabaseSettings;
		private ReportControl Report;
		private umfrage2._2007.Controls.SettingsControl Settings;
		private umfrage2._2007.Controls.SingleControl Singles;
		private BenchmarkControl Benchmarking;
		private ScoringControl Scoring;
		private Panel panel1;

		private Button SettingsButton;
		private Button ReportButton;
		private Button QuitButton;
		private Button SingleButton;

		private Evaluation eval;

		public EvaluationControl(Evaluation eval)
		{
			this.eval = eval;

			InitializeComponent();


			DatabaseSettings = new DatabaseSettingsControl(eval);
			DatabaseSettings.Dock = DockStyle.Fill;

			Report = new ReportControl(eval);
			Report.Dock = DockStyle.Fill;

			Settings = new umfrage2._2007.Controls.SettingsControl(eval);
			Settings.Dock = DockStyle.Fill;

			Singles = new umfrage2._2007.Controls.SingleControl(eval);
			Singles.Dock = DockStyle.Fill;

			Benchmarking = new BenchmarkControl(eval);
			Benchmarking.Dock = DockStyle.Fill;

			Scoring = new ScoringControl(eval);
			Scoring.Dock = DockStyle.Fill;


			panel1.Controls.Add(DatabaseSettings);
			panel1.Controls.Add(Report);
			panel1.Controls.Add(Settings);
			panel1.Controls.Add(Singles);
			panel1.Controls.Add(Benchmarking);
			panel1.Controls.Add(Scoring);

			HideAll();

			DatabaseSettings.Visible = true;
		}

		private void HideAll()
		{
			DatabaseSettings.Visible = false;
			Report.Visible = false;
			Settings.Visible = false;
			Singles.Visible = false;
			Benchmarking.Visible = false;
			Scoring.Visible = false;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ResourceManager resources = new ResourceManager(typeof(EvaluationControl));
			this.NaviagationPanel = new Panel();
			this.SingleButton = new Button();
			this.QuitButton = new Button();
			this.button4 = new Button();
			this.button3 = new Button();
			this.ReportButton = new Button();
			this.SettingsButton = new Button();
			this.DatabaseButton = new Button();
			this.panel1 = new Panel();
			this.NaviagationPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// NaviagationPanel
			// 
			this.NaviagationPanel.BackColor = Color.White;
			this.NaviagationPanel.Controls.Add(this.SingleButton);
			this.NaviagationPanel.Controls.Add(this.QuitButton);
			this.NaviagationPanel.Controls.Add(this.button4);
			this.NaviagationPanel.Controls.Add(this.button3);
			this.NaviagationPanel.Controls.Add(this.ReportButton);
			this.NaviagationPanel.Controls.Add(this.SettingsButton);
			this.NaviagationPanel.Controls.Add(this.DatabaseButton);
			this.NaviagationPanel.Dock = DockStyle.Left;
			this.NaviagationPanel.Location = new Point(0, 0);
			this.NaviagationPanel.Name = "NaviagationPanel";
			this.NaviagationPanel.Size = new Size(160, 500);
			this.NaviagationPanel.TabIndex = 1;
			// 
			// SingleButton
			// 
			this.SingleButton.BackColor = Color.LightGray;
			this.SingleButton.FlatStyle = FlatStyle.Popup;
			this.SingleButton.Image = ((Image)(resources.GetObject("SingleButton.Image")));
			this.SingleButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.SingleButton.Location = new Point(8, 128);
			this.SingleButton.Name = "SingleButton";
			this.SingleButton.Size = new Size(136, 32);
			this.SingleButton.TabIndex = 6;
			this.SingleButton.Text = "Einzelgrafiken";
			this.SingleButton.Click += new EventHandler(this.SingleButton_Click);
			// 
			// QuitButton
			// 
			this.QuitButton.BackColor = Color.LightGray;
			this.QuitButton.FlatStyle = FlatStyle.Popup;
			this.QuitButton.Image = ((Image)(resources.GetObject("QuitButton.Image")));
			this.QuitButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.QuitButton.Location = new Point(8, 288);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new Size(136, 32);
			this.QuitButton.TabIndex = 5;
			this.QuitButton.Text = "Schliessen";
			this.QuitButton.Click += new EventHandler(this.QuitButton_Click);
			// 
			// button4
			// 
			this.button4.BackColor = Color.LightGray;
			this.button4.FlatStyle = FlatStyle.Popup;
			this.button4.Image = ((Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = ContentAlignment.MiddleLeft;
			this.button4.Location = new Point(8, 208);
			this.button4.Name = "button4";
			this.button4.Size = new Size(136, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "Benchmarking   ";
			this.button4.Click += new EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.BackColor = Color.LightGray;
			this.button3.FlatStyle = FlatStyle.Popup;
			this.button3.Image = ((Image)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = ContentAlignment.MiddleLeft;
			this.button3.Location = new Point(8, 168);
			this.button3.Name = "button3";
			this.button3.Size = new Size(136, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "Scoring";
			this.button3.Click += new EventHandler(this.button3_Click);
			// 
			// ReportButton
			// 
			this.ReportButton.BackColor = Color.LightGray;
			this.ReportButton.FlatStyle = FlatStyle.Popup;
			this.ReportButton.Image = ((Image)(resources.GetObject("ReportButton.Image")));
			this.ReportButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.ReportButton.Location = new Point(8, 88);
			this.ReportButton.Name = "ReportButton";
			this.ReportButton.Size = new Size(136, 32);
			this.ReportButton.TabIndex = 2;
			this.ReportButton.Text = "Berichte";
			this.ReportButton.Click += new EventHandler(this.ReportButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.BackColor = Color.LightGray;
			this.SettingsButton.FlatStyle = FlatStyle.Popup;
			this.SettingsButton.Image = ((Image)(resources.GetObject("SettingsButton.Image")));
			this.SettingsButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.SettingsButton.Location = new Point(8, 48);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new Size(136, 32);
			this.SettingsButton.TabIndex = 1;
			this.SettingsButton.Text = "Einstellungen";
			this.SettingsButton.Click += new EventHandler(this.SettingsButton_Click);
			// 
			// DatabaseButton
			// 
			this.DatabaseButton.BackColor = Color.LightGray;
			this.DatabaseButton.FlatStyle = FlatStyle.Popup;
			this.DatabaseButton.Image = ((Image)(resources.GetObject("DatabaseButton.Image")));
			this.DatabaseButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.DatabaseButton.Location = new Point(8, 8);
			this.DatabaseButton.Name = "DatabaseButton";
			this.DatabaseButton.Size = new Size(136, 32);
			this.DatabaseButton.TabIndex = 0;
			this.DatabaseButton.Text = "Datenbank";
			this.DatabaseButton.Click += new EventHandler(this.DatabaseButton_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = Color.Gainsboro;
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(160, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(634, 500);
			this.panel1.TabIndex = 2;
			// 
			// EvaluationControl
			// 
			this.BackColor = Color.White;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.NaviagationPanel);
			this.Font = new Font("Arial", 8F);
			this.Name = "EvaluationControl";
			this.Size = new Size(794, 500);
			this.NaviagationPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DatabaseButton_Click(object sender, EventArgs e)
		{
			HideAll();
			DatabaseSettings.Visible = true;
		}

		private void ReportButton_Click(object sender, EventArgs e)
		{
		    HideAll();
			Report.Visible = true;
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			HideAll();
			Settings.Visible = true;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SingleButton_Click(object sender, EventArgs e)
		{
			HideAll();
			Singles.Visible = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			HideAll();
			Benchmarking.Visible = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			HideAll();
			Scoring.Visible = true;
		}
	}
}
