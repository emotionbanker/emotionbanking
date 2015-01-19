using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogUpdateResults : DialogTemplate
	{
		private Panel HeaderPanel;
		public Label label1;
		private PictureBox pictureBox1;
		private Label label2;
		private Label StatusLabel;
		private IContainer components = null;
		private Button ControlButton;

		public Label LocalPercent;
		public Label GlobalPercent;
		private Label label3;
		public Label TimeRemainingLabel;
		public Button DoneButton;
		public Label TimeElapsedLabel;
		private Label elaps;

		private Evaluation eval;

		public DialogUpdateResults(Evaluation eval)
		{
			this.eval = eval;

			InitializeComponent();
		}

		public void Status(string text)
		{
			StatusLabel.Text = text;
			Refresh();
		}

		public void Begin()
		{
            //NEW VERSION FIX
			//eval.UpdateData(this);

			/*
			Status("öffne Datenbank");
			MySQLConnection db = new MySQLConnection(new MySQLConnectionString(eval.DatabaseHost, eval.DatabaseName, eval.DatabaseUser, eval.DatabasePassword).AsString);

			try
			{
				db.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim öffnen der Datenbank!\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Status("Initialisiere...");
			
			eval.LoadTargetData(db);

			Status("Initialisiere...");
			
			eval.LoadResultData(db, this);

			
			Status("Lade Personendaten und Zugangsdaten...");
			eval.LoadPersonData();
			

			Status("beende Datenbankverbindung");
			db.Close();
			Status("Vorgang abgeschlossen");

			GlobalStatus.Value = GlobalStatus.Max;
			LocalStatus.Value = LocalStatus.Max;
			Refresh();

			TimeRemainingLabel.Text = "";
			
			DoneButton.Enabled = true;
			*/
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ResourceManager resources = new ResourceManager(typeof(DialogUpdateResults));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.label2 = new Label();
			this.StatusLabel = new Label();
			this.ControlButton = new Button();
			this.LocalPercent = new Label();
			this.GlobalPercent = new Label();
			this.label3 = new Label();
			this.TimeRemainingLabel = new Label();
			this.DoneButton = new Button();
			this.TimeElapsedLabel = new Label();
			this.elaps = new Label();
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
			this.HeaderPanel.Size = new Size(634, 80);
			this.HeaderPanel.TabIndex = 2;
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
			this.label1.Text = "Laden der Ergebnisse";
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
			// LocalStatus
			// 
			// 
			// label2
			// 
			this.label2.Location = new Point(16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new Size(64, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Status:";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Location = new Point(80, 96);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(528, 23);
			this.StatusLabel.TabIndex = 5;
			// 
			// ControlButton
			// 
			this.ControlButton.BackColor = Color.LightGray;
			this.ControlButton.FlatStyle = FlatStyle.Popup;
			this.ControlButton.Location = new Point(16, 248);
			this.ControlButton.Name = "ControlButton";
			this.ControlButton.Size = new Size(104, 32);
			this.ControlButton.TabIndex = 6;
			this.ControlButton.Text = "Start";
			this.ControlButton.Click += new EventHandler(this.ControlButton_Click);
			// 
			// GlobalStatus
			// 
			// 
			// LocalPercent
			// 
			this.LocalPercent.Location = new Point(584, 136);
			this.LocalPercent.Name = "LocalPercent";
			this.LocalPercent.Size = new Size(40, 32);
			this.LocalPercent.TabIndex = 8;
			this.LocalPercent.Text = "0%";
			this.LocalPercent.TextAlign = ContentAlignment.TopRight;
			// 
			// GlobalPercent
			// 
			this.GlobalPercent.Location = new Point(584, 192);
			this.GlobalPercent.Name = "GlobalPercent";
			this.GlobalPercent.Size = new Size(40, 32);
			this.GlobalPercent.TabIndex = 9;
			this.GlobalPercent.Text = "0%";
			this.GlobalPercent.TextAlign = ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new Point(144, 240);
			this.label3.Name = "label3";
			this.label3.Size = new Size(136, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Verbleibende Zeit:";
			this.label3.TextAlign = ContentAlignment.TopRight;
			// 
			// TimeRemainingLabel
			// 
			this.TimeRemainingLabel.Location = new Point(288, 240);
			this.TimeRemainingLabel.Name = "TimeRemainingLabel";
			this.TimeRemainingLabel.Size = new Size(208, 23);
			this.TimeRemainingLabel.TabIndex = 11;
			this.TimeRemainingLabel.Text = "unbekannt";
			// 
			// DoneButton
			// 
			this.DoneButton.BackColor = Color.LightGray;
			this.DoneButton.Enabled = false;
			this.DoneButton.FlatStyle = FlatStyle.Popup;
			this.DoneButton.Location = new Point(504, 248);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new Size(104, 32);
			this.DoneButton.TabIndex = 12;
			this.DoneButton.Text = "Fortfahren";
			this.DoneButton.Click += new EventHandler(this.DoneButton_Click);
			// 
			// TimeElapsedLabel
			// 
			this.TimeElapsedLabel.Location = new Point(288, 272);
			this.TimeElapsedLabel.Name = "TimeElapsedLabel";
			this.TimeElapsedLabel.Size = new Size(208, 23);
			this.TimeElapsedLabel.TabIndex = 14;
			// 
			// elaps
			// 
			this.elaps.Location = new Point(144, 272);
			this.elaps.Name = "elaps";
			this.elaps.Size = new Size(136, 24);
			this.elaps.TabIndex = 15;
			this.elaps.Text = "Verstrichene Zeit:";
			this.elaps.TextAlign = ContentAlignment.TopRight;
			// 
			// DialogUpdateResults
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(634, 310);
			this.Controls.Add(this.elaps);
			this.Controls.Add(this.TimeElapsedLabel);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.TimeRemainingLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.GlobalPercent);
			this.Controls.Add(this.LocalPercent);
			this.Controls.Add(this.ControlButton);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "DialogUpdateResults";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ControlButton_Click(object sender, EventArgs e)
		{
			ControlButton.Enabled = false;
			Begin();
		}

		private void DoneButton_Click(object sender, EventArgs e)
		{
			eval.lastResultUpdate = DateTime.Now;
			eval.resultDataChanged(this);
			eval.personDataChanged(this);
			eval.reportDataChanged(this);
			Close();
		}
	}
}

