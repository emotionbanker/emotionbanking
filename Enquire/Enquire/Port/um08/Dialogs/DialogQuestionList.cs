using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogQuestionList : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private Button EndButton;
		private Button SaveButton;
		private Button BrowseButton;
		private TextBox PathBox;
		private Label label2;
		private IContainer components = null;


		private Evaluation eval;
		private Panel PersonPanel;
		private SaveFileDialog openFileDialog;

		private ChoosePersonControl cpc;

		public string Filename
		{
			get {return PathBox.Text;}
		}

		public DialogQuestionList(Evaluation eval)
		{
			InitializeComponent();

			this.CancelButton = EndButton;

			this.eval = eval;
			
			cpc = new ChoosePersonControl(eval, false);
			cpc.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpc);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DialogQuestionList));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.EndButton = new Button();
            this.SaveButton = new Button();
            this.BrowseButton = new Button();
            this.PathBox = new TextBox();
            this.label2 = new Label();
            this.PersonPanel = new Panel();
            this.openFileDialog = new SaveFileDialog();
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
            this.HeaderPanel.Size = new Size(538, 65);
            this.HeaderPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(460, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fragenlist";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(53, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.LightGray;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Location = new Point(293, 150);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(140, 26);
            this.EndButton.TabIndex = 25;
            this.EndButton.Text = "Abbrechen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.LightGray;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Location = new Point(293, 182);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(140, 26);
            this.SaveButton.TabIndex = 24;
            this.SaveButton.Text = "Speichern";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = Color.LightGray;
            this.BrowseButton.FlatStyle = FlatStyle.Popup;
            this.BrowseButton.Location = new Point(380, 78);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new Size(53, 20);
            this.BrowseButton.TabIndex = 21;
            this.BrowseButton.Text = "ändern...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new EventHandler(this.BrowseButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.BorderStyle = BorderStyle.FixedSingle;
            this.PathBox.Location = new Point(67, 78);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new Size(300, 20);
            this.PathBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Location = new Point(-13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new Size(73, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Datei:";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new Point(67, 104);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new Size(193, 104);
            this.PersonPanel.TabIndex = 26;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xlsx";
            this.openFileDialog.Filter = "Excel- Dateien|*.xlsx";
            // 
            // DialogQuestionList
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(538, 270);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "DialogQuestionList";
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void SaveButton_Click(object sender, EventArgs e)
		{
			QuestionExport qe = new QuestionExport(eval, cpc.SelectedPersons);

			qe.SaveAsExcel(this.Filename);

			Close();
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				PathBox.Text = openFileDialog.FileName;
		}
	}
}

