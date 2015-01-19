using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for ScoringControl.
	/// </summary>
	public class ScoringControl : UserControl
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private DataStatusControl StatusControl;
		private GroupBox groupBox3;
		private Panel targetBox;

		private Evaluation eval;
		private ListBox ColumnBox;
		private Button EditColumnButton;
		private Button DeleteColumnButton;
		private Button NewColumnButton;
		private GroupBox ScoringG;
		private Button ScoreButton;
		private CheckBox Cockpits;
		private CheckBox Cockpits06;

		private ChooseTargetControl TargetSelector;

		public ScoringControl(Evaluation eval)
		{
			InitializeComponent();
			
			this.eval = eval;

			StatusControl = new DataStatusControl(eval);
			StatusControl.Location = new Point(8,88);

			this.Controls.Add(StatusControl);

			TargetSelector = new ChooseTargetControl(eval);
			TargetSelector.Dock = DockStyle.Fill;

			targetBox.Controls.Add(TargetSelector);

			foreach (Column c in eval.Columns)
				ColumnBox.Items.Add(c);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ScoringControl));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.groupBox3 = new GroupBox();
            this.targetBox = new Panel();
            this.ScoringG = new GroupBox();
            this.Cockpits06 = new CheckBox();
            this.Cockpits = new CheckBox();
            this.ScoreButton = new Button();
            this.EditColumnButton = new Button();
            this.DeleteColumnButton = new Button();
            this.NewColumnButton = new Button();
            this.ColumnBox = new ListBox();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.ScoringG.SuspendLayout();
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
            this.HeaderPanel.Size = new Size(624, 80);
            this.HeaderPanel.TabIndex = 3;
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
            this.label1.Text = "Scoring";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetBox);
            this.groupBox3.Location = new Point(8, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(168, 272);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zielauswahl";
            // 
            // targetBox
            // 
            this.targetBox.Dock = DockStyle.Fill;
            this.targetBox.Location = new Point(3, 19);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new Size(162, 250);
            this.targetBox.TabIndex = 36;
            // 
            // ScoringG
            // 
            this.ScoringG.Controls.Add(this.Cockpits06);
            this.ScoringG.Controls.Add(this.Cockpits);
            this.ScoringG.Controls.Add(this.ScoreButton);
            this.ScoringG.Controls.Add(this.EditColumnButton);
            this.ScoringG.Controls.Add(this.DeleteColumnButton);
            this.ScoringG.Controls.Add(this.NewColumnButton);
            this.ScoringG.Controls.Add(this.ColumnBox);
            this.ScoringG.Location = new Point(192, 216);
            this.ScoringG.Name = "ScoringG";
            this.ScoringG.Size = new Size(400, 272);
            this.ScoringG.TabIndex = 42;
            this.ScoringG.TabStop = false;
            this.ScoringG.Text = "Scoring";
            // 
            // Cockpits06
            // 
            this.Cockpits06.Location = new Point(216, 184);
            this.Cockpits06.Name = "Cockpits06";
            this.Cockpits06.Size = new Size(168, 24);
            this.Cockpits06.TabIndex = 39;
            this.Cockpits06.Text = "victor 06 Cockpits";
            this.Cockpits06.CheckedChanged += new EventHandler(this.Cockpits06_CheckedChanged);
            // 
            // Cockpits
            // 
            this.Cockpits.Location = new Point(216, 152);
            this.Cockpits.Name = "Cockpits";
            this.Cockpits.Size = new Size(168, 24);
            this.Cockpits.TabIndex = 38;
            this.Cockpits.Text = "victor 05 Cockpits";
            this.Cockpits.CheckedChanged += new EventHandler(this.Cockpits_CheckedChanged);
            // 
            // ScoreButton
            // 
            this.ScoreButton.BackColor = Color.LightGray;
            this.ScoreButton.FlatStyle = FlatStyle.Popup;
            this.ScoreButton.Location = new Point(216, 224);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new Size(168, 32);
            this.ScoreButton.TabIndex = 37;
            this.ScoreButton.Text = "Berechnen";
            this.ScoreButton.UseVisualStyleBackColor = false;
            this.ScoreButton.Click += new EventHandler(this.ScoreButton_Click);
            // 
            // EditColumnButton
            // 
            this.EditColumnButton.BackColor = Color.LightGray;
            this.EditColumnButton.FlatStyle = FlatStyle.Popup;
            this.EditColumnButton.Location = new Point(216, 104);
            this.EditColumnButton.Name = "EditColumnButton";
            this.EditColumnButton.Size = new Size(168, 32);
            this.EditColumnButton.TabIndex = 36;
            this.EditColumnButton.Text = "Säule bearbeiten";
            this.EditColumnButton.UseVisualStyleBackColor = false;
            this.EditColumnButton.Click += new EventHandler(this.EditColumnButton_Click);
            // 
            // DeleteColumnButton
            // 
            this.DeleteColumnButton.BackColor = Color.LightGray;
            this.DeleteColumnButton.FlatStyle = FlatStyle.Popup;
            this.DeleteColumnButton.Location = new Point(216, 64);
            this.DeleteColumnButton.Name = "DeleteColumnButton";
            this.DeleteColumnButton.Size = new Size(168, 32);
            this.DeleteColumnButton.TabIndex = 35;
            this.DeleteColumnButton.Text = "Säule löschen";
            this.DeleteColumnButton.UseVisualStyleBackColor = false;
            this.DeleteColumnButton.Click += new EventHandler(this.DeleteColumnButton_Click);
            // 
            // NewColumnButton
            // 
            this.NewColumnButton.BackColor = Color.LightGray;
            this.NewColumnButton.FlatStyle = FlatStyle.Popup;
            this.NewColumnButton.Location = new Point(216, 24);
            this.NewColumnButton.Name = "NewColumnButton";
            this.NewColumnButton.Size = new Size(168, 32);
            this.NewColumnButton.TabIndex = 34;
            this.NewColumnButton.Text = "Neue Säule";
            this.NewColumnButton.UseVisualStyleBackColor = false;
            this.NewColumnButton.Click += new EventHandler(this.NewColumnButton_Click);
            // 
            // ColumnBox
            // 
            this.ColumnBox.BorderStyle = BorderStyle.FixedSingle;
            this.ColumnBox.HorizontalScrollbar = true;
            this.ColumnBox.ItemHeight = 16;
            this.ColumnBox.Location = new Point(8, 19);
            this.ColumnBox.Name = "ColumnBox";
            this.ColumnBox.Size = new Size(192, 242);
            this.ColumnBox.TabIndex = 33;
            this.ColumnBox.DoubleClick += new EventHandler(this.ColumnBox_DoubleClick);
            // 
            // ScoringControl
            // 
            this.BackColor = Color.Gainsboro;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ScoringG);
            this.Controls.Add(this.HeaderPanel);
            this.Font = new Font("Arial", 8F);
            this.Name = "ScoringControl";
            this.Size = new Size(624, 512);
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ScoringG.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void UpdateData()
		{
			ColumnBox.Items.Clear();

			foreach (Column c in eval.Columns)
				ColumnBox.Items.Add(c);
		}

		private void NewColumnButton_Click(object sender, EventArgs e)
		{
			Column nc = new Column();
			eval.AddColumn(nc);
			ColumnBox.Items.Add(nc);

			DialogColumn dc = new DialogColumn(eval, nc);
			dc.ShowDialog();
			UpdateData();
		}

		private void DeleteColumnButton_Click(object sender, EventArgs e)
		{
			if (ColumnBox.SelectedItem != null)
			{
				eval.RemoveColumn((Column)ColumnBox.SelectedItem);
				ColumnBox.Items.Remove(ColumnBox.SelectedItem);
			}
		}

		private void EditColumnButton_Click(object sender, EventArgs e)
		{
			if (ColumnBox.SelectedItem != null)
			{
				DialogColumn dc = new DialogColumn(eval, (Column)ColumnBox.SelectedItem);
				dc.ShowDialog();
				UpdateData();
			}
		}

		private void ColumnBox_DoubleClick(object sender, EventArgs e)
		{
			if (ColumnBox.SelectedItem != null)
			{
				DialogColumn dc = new DialogColumn(eval, (Column)ColumnBox.SelectedItem);
				dc.ShowDialog();
				UpdateData();
			}
		}

		private void ScoreButton_Click(object sender, EventArgs e)
		{
			Scoring sc = new Scoring(eval, Cockpits.Checked, Cockpits06.Checked, false);
			SaveDialog sd = new SaveDialog(sc);
			sd.ShowDialog();
		}

		private void Cockpits_CheckedChanged(object sender, EventArgs e)
		{
		}

        private void Cockpits06_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
