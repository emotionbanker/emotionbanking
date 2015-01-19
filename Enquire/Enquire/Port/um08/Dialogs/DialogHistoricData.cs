using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogHistoricData : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private Button EndButton;
		private Button SaveButton;
		private TextBox NameBox;
		private Label label3;
		private Button BrowseButton;
		private TextBox PathBox;
		private Label label2;
		private OpenFileDialog openFileDialog;
		private Label label4;
        private TextBox boxId;
        private Label label5;
		private IContainer components = null;


		public string Filename
		{
			get {return PathBox.Text;}
		}

		public int Percent
		{
			get {return Int32.Parse(NameBox.Text);}
		}

        public HistoricData Historic
		{
			get
			{
                HistoricData hd = new HistoricData();
				hd.DocumentPath = Filename;
				hd.Percent = (float)Percent;
			    hd.Name = boxId.Text;
				if (hd.LoadInfo())
					return hd;
				else
					return null;
			}
		}

        public DialogHistoricData(HistoricData hd)
		{
			InitializeComponent();

			this.CancelButton = EndButton;

			NameBox.Text = hd.Percent + "";
			PathBox.Text = hd.DocumentPath;
		    boxId.Text = hd.Name;

            openFileDialog.Filter = "Umfragedaten|*.um2;*.um3";
		}

		public DialogHistoricData()
		{
			InitializeComponent();

			this.CancelButton = EndButton;

			NameBox.Text = "0";
		    boxId.Text = "";

            openFileDialog.Filter = "Umfragedaten|*.um2;*.um3";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogHistoricData));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EndButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.boxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.pictureBox1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(538, 65);
            this.HeaderPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historische Daten";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(80, 177);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(140, 26);
            this.EndButton.TabIndex = 25;
            this.EndButton.Text = "Abbrechen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(240, 177);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 26);
            this.SaveButton.TabIndex = 24;
            this.SaveButton.Text = "Öffnen";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameBox.Location = new System.Drawing.Point(80, 110);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(47, 20);
            this.NameBox.TabIndex = 23;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Gewichtung:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.LightGray;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BrowseButton.Location = new System.Drawing.Point(393, 78);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(54, 20);
            this.BrowseButton.TabIndex = 21;
            this.BrowseButton.Text = "ändern...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathBox.Location = new System.Drawing.Point(80, 78);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(300, 20);
            this.PathBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Datei:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "um2";
            this.openFileDialog.Filter = "Umfragedaten|*.um2";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(133, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "(in Prozent, zwischen 0 und 100)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // boxId
            // 
            this.boxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxId.Location = new System.Drawing.Point(80, 140);
            this.boxId.Name = "boxId";
            this.boxId.Size = new System.Drawing.Size(300, 20);
            this.boxId.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DialogHistoricData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(538, 230);
            this.Controls.Add(this.boxId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "DialogHistoricData";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (!File.Exists(PathBox.Text))
			{
				MessageBox.Show("Die angegebene Datei existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				PathBox.Text = openFileDialog.FileName;
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				Int32.Parse(NameBox.Text);
			}
			catch
			{
				NameBox.Text = "0";
			}

			if (Percent < 0) NameBox.Text = "0";
			if (Percent > 100) NameBox.Text = "100";
		}
	}
}

