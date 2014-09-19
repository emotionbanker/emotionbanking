using System;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class SaveReportDialog : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private Button BrowseButton;
		private TextBox PathBox;
		private Label label2;
		private Button EndButton;
		private Button SaveButton;
		private FolderBrowserDialog Browser;
		private Label label3;
		private Label StatusLabel;
		private CheckBox FolderBox;
		private IContainer components = null;
		private GroupBox targetBox;

		private Report report;
		private ComboBox EvalSelector;

		private ChooseTargetControl TargetSelector;

		public SaveReportDialog(Evaluation eval, Report report)
		{
			this.report = report;

			InitializeComponent();

			this.CancelButton = EndButton;

			TargetSelector = new ChooseTargetControl(eval);
			TargetSelector.Dock = DockStyle.Fill;

			targetBox.Controls.Add(TargetSelector);

			EvalSelector.Items.Add(eval);

			foreach (HistoricData hd in eval.History)
				EvalSelector.Items.Add(hd.Eval);

			EvalSelector.SelectedItem = eval;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SaveReportDialog));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.BrowseButton = new Button();
            this.PathBox = new TextBox();
            this.label2 = new Label();
            this.EndButton = new Button();
            this.SaveButton = new Button();
            this.Browser = new FolderBrowserDialog();
            this.FolderBox = new CheckBox();
            this.label3 = new Label();
            this.StatusLabel = new Label();
            this.targetBox = new GroupBox();
            this.EvalSelector = new ComboBox();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.HeaderPanel.Size = new Size(570, 80);
            this.HeaderPanel.TabIndex = 5;
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
            this.label1.Text = "Bericht auswerten";
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
            // BrowseButton
            // 
            this.BrowseButton.BackColor = Color.LightGray;
            this.BrowseButton.FlatStyle = FlatStyle.Popup;
            this.BrowseButton.Location = new Point(488, 96);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new Size(64, 24);
            this.BrowseButton.TabIndex = 14;
            this.BrowseButton.Text = "ändern...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new EventHandler(this.BrowseButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.BorderStyle = BorderStyle.FixedSingle;
            this.PathBox.Location = new Point(232, 128);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new Size(320, 23);
            this.PathBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new Point(232, 96);
            this.label2.Name = "label2";
            this.label2.Size = new Size(72, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ordner:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.LightGray;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Location = new Point(200, 360);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(168, 32);
            this.EndButton.TabIndex = 20;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.LightGray;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Location = new Point(392, 360);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(168, 32);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Auswerten";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // FolderBox
            // 
            this.FolderBox.Location = new Point(232, 160);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new Size(320, 24);
            this.FolderBox.TabIndex = 21;
            this.FolderBox.Text = "Auswertungen in seperaten Ordnern speichern";
            // 
            // StatusBar
            // 
            // 
            // label3
            // 
            this.label3.Location = new Point(8, 272);
            this.label3.Name = "label3";
            this.label3.Size = new Size(48, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new Point(56, 272);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new Size(504, 16);
            this.StatusLabel.TabIndex = 24;
            this.StatusLabel.Text = "Warte auf Eingabe";
            // 
            // targetBox
            // 
            this.targetBox.Location = new Point(8, 86);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new Size(200, 176);
            this.targetBox.TabIndex = 25;
            this.targetBox.TabStop = false;
            this.targetBox.Text = "Zielauswahl";
            // 
            // EvalSelector
            // 
            this.EvalSelector.Location = new Point(232, 192);
            this.EvalSelector.Name = "EvalSelector";
            this.EvalSelector.Size = new Size(320, 24);
            this.EvalSelector.TabIndex = 26;
            this.EvalSelector.SelectedIndexChanged += new EventHandler(this.EvalSelector_SelectedIndexChanged);
            // 
            // SaveReportDialog
            // 
            this.AutoScaleBaseSize = new Size(6, 16);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(570, 406);
            this.Controls.Add(this.EvalSelector);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FolderBox);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "SaveReportDialog";
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void UpdateEval()
		{
			targetBox.Controls.Clear();

			TargetSelector = new ChooseTargetControl((Evaluation)EvalSelector.SelectedItem);
			TargetSelector.Dock = DockStyle.Fill;

			targetBox.Controls.Add(TargetSelector);
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			if (Browser.ShowDialog() == DialogResult.OK)
			{
				PathBox.Text = Browser.SelectedPath;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(PathBox.Text))
			{
				MessageBox.Show("Der ausgewählte Ordner existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			StatusLabel.Text = "Werte aus...";
			SaveButton.Enabled = EndButton.Enabled = false;
			Refresh();
			report.Save(PathBox.Text, FolderBox.Checked, StatusLabel, (Evaluation)EvalSelector.SelectedItem);
			StatusLabel.Text = "Bericht wurde erstellt";
			SaveButton.Enabled = EndButton.Enabled = true;
			Refresh();
			InfoBox.Show("Bericht", "Alle Auswertungen in diesem Bericht wurden erstellt");
		}

		private void EvalSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateEval();
		}
	}
}

