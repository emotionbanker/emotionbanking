using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2
{
	public class OutputFormBar : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components = null;


		public Bar bar;
		private PreviewControl previewBox;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Panel PersonPanel;
		private SizeControl sizeControl;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private Evaluation eval;

		public bool single;

		private ChoosePersonControl cpp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button QRemove;
		private System.Windows.Forms.Button QAdd;
		private System.Windows.Forms.ListBox QBox;
		private System.Windows.Forms.Button OverloadButton;
		private System.Windows.Forms.CheckBox InvertBox;
		private System.Windows.Forms.CheckBox PcntBox;
		private System.Windows.Forms.CheckBox HorBox;
		private System.Windows.Forms.CheckBox ShowBox;
		private System.Windows.Forms.Button QFontButton;
		private System.Windows.Forms.FontDialog QFontDialog;
        private Panel BColorPanel;
        private Button BColorButton;
        private ColorDialog colorDialog;
		private Crossing cross;

		public OutputFormBar(Evaluation eval)
		{
            Set(eval, true, new Bar(eval));
		}

		public OutputFormBar(Evaluation eval, bool single)
		{
            Set(eval, single, new Bar(eval));
		}

		public OutputFormBar(Evaluation eval, bool single, Bar bar)
		{
			Set(eval, single, bar);

			EndButton.Visible = false;
			
			cpp.SetSelection(bar.PersonList, bar.ComboList);

			sizeControl.SetSize(bar.width, bar.height);

			//question lists

			foreach (Question q in bar.Questions)
				QBox.Items.Add(q);	

			Preview();
		}

		private void Set(Evaluation eval, bool single, Bar bar)
		{
			this.eval = eval;
			this.single = single;

			this.bar = bar;

			InitializeComponent();

			this.CancelButton = EndButton;

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(bar.Cross);

			OutputNameControl onc = new OutputNameControl(bar);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
			}

			InvertBox.Checked = bar.invert;
			PcntBox.Checked = bar.Percent;
			HorBox.Checked = bar.Horizontal;

			ShowBox.Checked = bar.ShowText;

			QFontDialog.Font = bar.Txt;

            BColorPanel.BackColor = bar.BackColor;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormBar));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.previewBox = new compucare.Enquire.Legacy.Umfrage2Lib.Controls.PreviewControl();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.sizeControl = new compucare.Enquire.Legacy.Umfrage2Lib.Controls.SizeControl();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.OverloadButton = new System.Windows.Forms.Button();
            this.InvertBox = new System.Windows.Forms.CheckBox();
            this.PcntBox = new System.Windows.Forms.CheckBox();
            this.HorBox = new System.Windows.Forms.CheckBox();
            this.ShowBox = new System.Windows.Forms.CheckBox();
            this.QFontButton = new System.Windows.Forms.Button();
            this.QFontDialog = new System.Windows.Forms.FontDialog();
            this.BColorPanel = new System.Windows.Forms.Panel();
            this.BColorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
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
            this.HeaderPanel.Size = new System.Drawing.Size(602, 65);
            this.HeaderPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Balkendiagramm";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 45);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
            this.previewBox.Location = new System.Drawing.Point(7, 78);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(293, 429);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 20;
            this.previewBox.Load += new System.EventHandler(this.previewBox_Load);
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(300, 214);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(193, 40);
            this.crossPanel.TabIndex = 25;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(307, 254);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(186, 78);
            this.PersonPanel.TabIndex = 24;
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
            this.sizeControl.Location = new System.Drawing.Point(407, 338);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(86, 46);
            this.sizeControl.TabIndex = 23;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(313, 479);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 26);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(313, 446);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(180, 26);
            this.EndButton.TabIndex = 21;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(453, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 26);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fragen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.LightGray;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(460, 143);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(27, 26);
            this.QRemove.TabIndex = 30;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.LightGray;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(460, 110);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(27, 26);
            this.QAdd.TabIndex = 29;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 14;
            this.QBox.Location = new System.Drawing.Point(307, 78);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(140, 86);
            this.QBox.TabIndex = 28;
            // 
            // OverloadButton
            // 
            this.OverloadButton.BackColor = System.Drawing.Color.LightGray;
            this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OverloadButton.Location = new System.Drawing.Point(313, 182);
            this.OverloadButton.Name = "OverloadButton";
            this.OverloadButton.Size = new System.Drawing.Size(180, 26);
            this.OverloadButton.TabIndex = 32;
            this.OverloadButton.Text = "Beschriftungen";
            this.OverloadButton.UseVisualStyleBackColor = false;
            this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
            // 
            // InvertBox
            // 
            this.InvertBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InvertBox.Location = new System.Drawing.Point(313, 338);
            this.InvertBox.Name = "InvertBox";
            this.InvertBox.Size = new System.Drawing.Size(94, 20);
            this.InvertBox.TabIndex = 33;
            this.InvertBox.Text = "Invertiert";
            this.InvertBox.CheckedChanged += new System.EventHandler(this.InvertBox_CheckedChanged);
            // 
            // PcntBox
            // 
            this.PcntBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PcntBox.Location = new System.Drawing.Point(313, 358);
            this.PcntBox.Name = "PcntBox";
            this.PcntBox.Size = new System.Drawing.Size(94, 19);
            this.PcntBox.TabIndex = 34;
            this.PcntBox.Text = "Prozente";
            this.PcntBox.CheckedChanged += new System.EventHandler(this.PcntBox_CheckedChanged);
            // 
            // HorBox
            // 
            this.HorBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HorBox.Location = new System.Drawing.Point(313, 377);
            this.HorBox.Name = "HorBox";
            this.HorBox.Size = new System.Drawing.Size(94, 19);
            this.HorBox.TabIndex = 35;
            this.HorBox.Text = "Horizontal";
            this.HorBox.CheckedChanged += new System.EventHandler(this.HorBox_CheckedChanged);
            // 
            // ShowBox
            // 
            this.ShowBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowBox.Location = new System.Drawing.Point(313, 396);
            this.ShowBox.Name = "ShowBox";
            this.ShowBox.Size = new System.Drawing.Size(94, 20);
            this.ShowBox.TabIndex = 36;
            this.ShowBox.Text = "Fragentexte";
            this.ShowBox.CheckedChanged += new System.EventHandler(this.ShowBox_CheckedChanged);
            // 
            // QFontButton
            // 
            this.QFontButton.BackColor = System.Drawing.Color.LightGray;
            this.QFontButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QFontButton.Location = new System.Drawing.Point(407, 390);
            this.QFontButton.Name = "QFontButton";
            this.QFontButton.Size = new System.Drawing.Size(86, 20);
            this.QFontButton.TabIndex = 47;
            this.QFontButton.Text = "Text...";
            this.QFontButton.UseVisualStyleBackColor = false;
            this.QFontButton.Click += new System.EventHandler(this.QFontButton_Click);
            // 
            // BColorPanel
            // 
            this.BColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BColorPanel.Location = new System.Drawing.Point(314, 422);
            this.BColorPanel.Name = "BColorPanel";
            this.BColorPanel.Size = new System.Drawing.Size(78, 19);
            this.BColorPanel.TabIndex = 48;
            // 
            // BColorButton
            // 
            this.BColorButton.BackColor = System.Drawing.Color.LightGray;
            this.BColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BColorButton.Location = new System.Drawing.Point(407, 422);
            this.BColorButton.Name = "BColorButton";
            this.BColorButton.Size = new System.Drawing.Size(86, 19);
            this.BColorButton.TabIndex = 49;
            this.BColorButton.Text = "Hintergrund...";
            this.BColorButton.UseVisualStyleBackColor = false;
            this.BColorButton.Click += new System.EventHandler(this.BColorButton_Click);
            // 
            // OutputFormBar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 625);
            this.Controls.Add(this.BColorButton);
            this.Controls.Add(this.BColorPanel);
            this.Controls.Add(this.QFontButton);
            this.Controls.Add(this.ShowBox);
            this.Controls.Add(this.HorBox);
            this.Controls.Add(this.PcntBox);
            this.Controls.Add(this.InvertBox);
            this.Controls.Add(this.OverloadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QRemove);
            this.Controls.Add(this.QAdd);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.sizeControl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormBar";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Preview()
		{
			if (QBox.Items.Count > 0)
			{
				bar.text = false;
				bar.eval = eval;
				bar.Cross = cross.Cross;
				bar.width = previewBox.Width;
				//bar.height = previewBox.Height - 30;
				bar.PersonList = cpp.SelectedPersons;
				bar.ComboList = cpp.SelectedCombos;
				
				bar.Questions = getList();

				bar.Compute();

				previewBox.SmallPreview = bar.OutputImage;

				bar.text = true;
				bar.width = sizeControl.ChosenWidth;
				//bar.height = sizeControl.ChosenHeight;

				bar.Compute();

				previewBox.BigPreview = bar.OutputImage;
			}
		}

		private void sizeControl_ChosenSizeChanged()
		{
			Preview();
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void QAdd_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					QBox.Items.Add(q);
			}
			Preview();
		}

		private void QRemove_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
			Preview();
		}

		private Question[] getList()
		{
			Question[] qs = new Question[QBox.Items.Count];				

			int i = 0;
			foreach (Question q in QBox.Items)
				qs[i++] = q;

			return qs;
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			if (QBox.Items.Count > 0)
			{
				bar.text = true;
				bar.eval = eval;
				bar.Cross = cross.Cross;
				bar.width = sizeControl.ChosenWidth;
				bar.height = sizeControl.ChosenHeight;
				bar.PersonList = cpp.SelectedPersons;
				bar.ComboList = cpp.SelectedCombos;
				
				bar.Questions = getList();
			}

			if (single && QBox.Items.Count > 0)
			{
				SaveDialog sd = new SaveDialog(bar);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		private void OverloadButton_Click(object sender, System.EventArgs e)
		{
			DialogTextOverload dto = new DialogTextOverload(eval, getList());
			dto.ShowDialog();

			Preview();
		}

		private void EndButton_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cross_CrossChanged()
		{
			bar.Cross = cross.cross;
		}

		private void InvertBox_CheckedChanged(object sender, System.EventArgs e)
		{
			bar.invert = InvertBox.Checked;
			Preview();
		}

		private void PcntBox_CheckedChanged(object sender, System.EventArgs e)
		{
			bar.Percent = PcntBox.Checked;
			Preview();
		}

		private void HorBox_CheckedChanged(object sender, System.EventArgs e)
		{
			bar.Horizontal = HorBox.Checked;
			Preview();
		}

		private void ShowBox_CheckedChanged(object sender, System.EventArgs e)
		{
			bar.ShowText = ShowBox.Checked;
			Preview();
		}

		private void QFontButton_Click(object sender, System.EventArgs e)
		{
			if (QFontDialog.ShowDialog() == DialogResult.OK)
				bar.Txt = QFontDialog.Font;

			Preview();
		}

        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private void BColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = bar.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bar.BackColor = colorDialog.Color;
                BColorPanel.BackColor = bar.BackColor;
                Preview();
            }

        }
	}
}

