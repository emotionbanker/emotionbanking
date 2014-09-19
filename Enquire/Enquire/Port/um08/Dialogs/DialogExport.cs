using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogExport : DialogTemplate
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
		private string Filename;
        private Panel ChooseTargetPanel;
        private Panel ChoosePersonPanel;
		private bool numbers;

        public ChoosePersonControl cpc;
        public ChooseTargetControl ctc;

		public DialogExport(Evaluation eval, string Filename, bool numbers)
		{
			this.eval = eval;
			this.Filename = Filename;
			this.numbers = numbers;

            cpc = new ChoosePersonControl(eval, false);
            ctc = new ChooseTargetControl(eval, false, false);

            cpc.Dock = ctc.Dock = DockStyle.Fill;

            InitializeComponent();

            ChoosePersonPanel.Controls.Add(cpc);
            ChooseTargetPanel.Controls.Add(ctc);

			
		}

		public void Status(string text)
		{
			StatusLabel.Text = text;
			Refresh();
		}

		public void Begin()
		{
			DataExport de = new DataExport(this.eval, this.numbers);
            //filename = filename.Substring(0, filename.LastIndexOf('.'));
            Filename = Filename.Substring(0, Filename.LastIndexOf('.'));
            Filename += ".xlsx";
            //MessageBox.Show("Filename: "+Filename+"\n");
			de.SaveAsExcel(Filename, this);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DialogExport));
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
            this.ChooseTargetPanel = new Panel();
            this.ChoosePersonPanel = new Panel();
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
            this.HeaderPanel.Size = new Size(634, 65);
            this.HeaderPanel.TabIndex = 2;
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
            this.label1.Text = "Datenexport";
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
            // LocalStatus
            // 
            // 
            // label2
            // 
            this.label2.Location = new Point(10, 155);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new Point(63, 151);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new Size(440, 19);
            this.StatusLabel.TabIndex = 5;
            // 
            // ControlButton
            // 
            this.ControlButton.BackColor = Color.LightGray;
            this.ControlButton.FlatStyle = FlatStyle.Popup;
            this.ControlButton.Location = new Point(10, 275);
            this.ControlButton.Name = "ControlButton";
            this.ControlButton.Size = new Size(87, 26);
            this.ControlButton.TabIndex = 6;
            this.ControlButton.Text = "Start";
            this.ControlButton.UseVisualStyleBackColor = false;
            this.ControlButton.Click += new EventHandler(this.ControlButton_Click);
            // 
            // GlobalStatus
            // 
            // 
            // LocalPercent
            // 
            this.LocalPercent.Location = new Point(483, 184);
            this.LocalPercent.Name = "LocalPercent";
            this.LocalPercent.Size = new Size(34, 26);
            this.LocalPercent.TabIndex = 8;
            this.LocalPercent.Text = "0%";
            this.LocalPercent.TextAlign = ContentAlignment.TopRight;
            // 
            // GlobalPercent
            // 
            this.GlobalPercent.Location = new Point(483, 229);
            this.GlobalPercent.Name = "GlobalPercent";
            this.GlobalPercent.Size = new Size(34, 26);
            this.GlobalPercent.TabIndex = 9;
            this.GlobalPercent.Text = "0%";
            this.GlobalPercent.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new Point(117, 268);
            this.label3.Name = "label3";
            this.label3.Size = new Size(113, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Verbleibende Zeit:";
            this.label3.TextAlign = ContentAlignment.TopRight;
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.Location = new Point(237, 268);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new Size(173, 19);
            this.TimeRemainingLabel.TabIndex = 11;
            this.TimeRemainingLabel.Text = "unbekannt";
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = Color.LightGray;
            this.DoneButton.Enabled = false;
            this.DoneButton.FlatStyle = FlatStyle.Popup;
            this.DoneButton.Location = new Point(390, 275);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new Size(87, 26);
            this.DoneButton.TabIndex = 12;
            this.DoneButton.Text = "Fortfahren";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new EventHandler(this.DoneButton_Click);
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.Location = new Point(237, 294);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new Size(148, 19);
            this.TimeElapsedLabel.TabIndex = 14;
            // 
            // elaps
            // 
            this.elaps.Location = new Point(117, 294);
            this.elaps.Name = "elaps";
            this.elaps.Size = new Size(113, 20);
            this.elaps.TabIndex = 15;
            this.elaps.Text = "Verstrichene Zeit:";
            this.elaps.TextAlign = ContentAlignment.TopRight;
            // 
            // ChooseTargetPanel
            // 
            this.ChooseTargetPanel.Location = new Point(7, 74);
            this.ChooseTargetPanel.Name = "ChooseTargetPanel";
            this.ChooseTargetPanel.Size = new Size(222, 76);
            this.ChooseTargetPanel.TabIndex = 16;
            // 
            // ChoosePersonPanel
            // 
            this.ChoosePersonPanel.Location = new Point(261, 74);
            this.ChoosePersonPanel.Name = "ChoosePersonPanel";
            this.ChoosePersonPanel.Size = new Size(216, 76);
            this.ChoosePersonPanel.TabIndex = 17;
            // 
            // DialogExport
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(634, 398);
            this.Controls.Add(this.ChoosePersonPanel);
            this.Controls.Add(this.ChooseTargetPanel);
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
            this.Name = "DialogExport";
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ControlButton_Click(object sender, EventArgs e)
		{
            ctc.Enabled = cpc.Enabled = false;
			ControlButton.Enabled = false;
			Begin();
		}

		private void DoneButton_Click(object sender, EventArgs e)
		{
            try
            {
                eval.lastResultUpdate = DateTime.Now;
                eval.resultDataChanged(this);
                eval.personDataChanged(this);
                eval.reportDataChanged(this);
            }
            catch { }

			Close();
		}
	}
}

