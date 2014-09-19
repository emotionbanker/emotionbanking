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
	public class OutputFormMultiMatrix : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private SizeControl sizeControl;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.ComponentModel.IContainer components = null;

		public MultiMatrix mm;
		private System.Windows.Forms.ListBox XBox;
		private System.Windows.Forms.ListBox YBox;
		private System.Windows.Forms.Button XAdd;
		private System.Windows.Forms.Button XRemove;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel PersonPanel;

		private Evaluation eval;
		private System.Windows.Forms.Button YRemove;
		private System.Windows.Forms.Button YAdd;
		private System.Windows.Forms.RadioButton ScaleButton;
		private System.Windows.Forms.RadioButton BasicButton;
		private System.Windows.Forms.CheckBox SmallButton;
		private System.Windows.Forms.Panel crossPanel;

		private ChoosePersonControl cpp;
		private Crossing cross;
		private System.Windows.Forms.Button OverloadButton;
		private PreviewControl previewBox;

		private bool single;

		public OutputFormMultiMatrix(Evaluation eval)
		{
			Set(eval, true, new MultiMatrix(eval));
		}

		public OutputFormMultiMatrix(Evaluation eval, bool single)
		{
			Set(eval, single, new MultiMatrix(eval));
		}

		public OutputFormMultiMatrix(Evaluation eval, bool single, MultiMatrix mmatrix)
		{
			Set(eval, single, mmatrix);

			EndButton.Visible = false;
			
			cpp.SetSelection(mmatrix.PersonList, mmatrix.ComboList);

			sizeControl.SetSize(mmatrix.width, mmatrix.height);

			//question lists

			SmallButton.Checked = mmatrix.Small;
			
			if (mmatrix.Format == Output.FORMAT_BASIC)
				BasicButton.Checked = true;
			else
				ScaleButton.Checked = true;

			foreach (Question q in mm.xq)
				XBox.Items.Add(q);
			foreach (Question q in mm.yq)
				YBox.Items.Add(q);

			Preview(false);
		}

		public void Set(Evaluation eval, bool single, MultiMatrix mmatrix)
		{
			this.single = single;
			this.eval = eval;
			mm = mmatrix;

			InitializeComponent();

			this.CancelButton=EndButton;

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(mm.Cross);

			OutputNameControl onc = new OutputNameControl(mm);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormMultiMatrix));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sizeControl = new SizeControl();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.XBox = new System.Windows.Forms.ListBox();
            this.YBox = new System.Windows.Forms.ListBox();
            this.XAdd = new System.Windows.Forms.Button();
            this.XRemove = new System.Windows.Forms.Button();
            this.YRemove = new System.Windows.Forms.Button();
            this.YAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.ScaleButton = new System.Windows.Forms.RadioButton();
            this.BasicButton = new System.Windows.Forms.RadioButton();
            this.SmallButton = new System.Windows.Forms.CheckBox();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.OverloadButton = new System.Windows.Forms.Button();
            this.previewBox = new PreviewControl();
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
            this.HeaderPanel.Size = new System.Drawing.Size(602, 80);
            this.HeaderPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrix";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
            this.sizeControl.Location = new System.Drawing.Point(488, 456);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(104, 56);
            this.sizeControl.TabIndex = 20;
            this.sizeControl.Load += new System.EventHandler(this.sizeControl_Load);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(376, 560);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(216, 32);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(376, 520);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(216, 32);
            this.EndButton.TabIndex = 18;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // XBox
            // 
            this.XBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XBox.HorizontalScrollbar = true;
            this.XBox.ItemHeight = 16;
            this.XBox.Location = new System.Drawing.Point(48, 88);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(248, 114);
            this.XBox.TabIndex = 21;
            // 
            // YBox
            // 
            this.YBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YBox.HorizontalScrollbar = true;
            this.YBox.ItemHeight = 16;
            this.YBox.Location = new System.Drawing.Point(304, 88);
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(248, 114);
            this.YBox.TabIndex = 22;
            // 
            // XAdd
            // 
            this.XAdd.BackColor = System.Drawing.Color.LightGray;
            this.XAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.XAdd.Location = new System.Drawing.Point(8, 88);
            this.XAdd.Name = "XAdd";
            this.XAdd.Size = new System.Drawing.Size(32, 32);
            this.XAdd.TabIndex = 23;
            this.XAdd.Text = "+";
            this.XAdd.UseVisualStyleBackColor = false;
            this.XAdd.Click += new System.EventHandler(this.XAdd_Click);
            // 
            // XRemove
            // 
            this.XRemove.BackColor = System.Drawing.Color.LightGray;
            this.XRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.XRemove.Location = new System.Drawing.Point(8, 128);
            this.XRemove.Name = "XRemove";
            this.XRemove.Size = new System.Drawing.Size(32, 32);
            this.XRemove.TabIndex = 24;
            this.XRemove.Text = "-";
            this.XRemove.UseVisualStyleBackColor = false;
            this.XRemove.Click += new System.EventHandler(this.XRemove_Click);
            // 
            // YRemove
            // 
            this.YRemove.BackColor = System.Drawing.Color.LightGray;
            this.YRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YRemove.Location = new System.Drawing.Point(560, 128);
            this.YRemove.Name = "YRemove";
            this.YRemove.Size = new System.Drawing.Size(32, 32);
            this.YRemove.TabIndex = 26;
            this.YRemove.Text = "-";
            this.YRemove.UseVisualStyleBackColor = false;
            this.YRemove.Click += new System.EventHandler(this.YRemove_Click);
            // 
            // YAdd
            // 
            this.YAdd.BackColor = System.Drawing.Color.LightGray;
            this.YAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YAdd.Location = new System.Drawing.Point(560, 88);
            this.YAdd.Name = "YAdd";
            this.YAdd.Size = new System.Drawing.Size(32, 32);
            this.YAdd.TabIndex = 25;
            this.YAdd.Text = "+";
            this.YAdd.UseVisualStyleBackColor = false;
            this.YAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 32);
            this.label2.TabIndex = 27;
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(560, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 32);
            this.label3.TabIndex = 28;
            this.label3.Text = "Y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(368, 288);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(224, 96);
            this.PersonPanel.TabIndex = 29;
            // 
            // ScaleButton
            // 
            this.ScaleButton.Checked = true;
            this.ScaleButton.Location = new System.Drawing.Point(368, 240);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(104, 24);
            this.ScaleButton.TabIndex = 30;
            this.ScaleButton.TabStop = true;
            this.ScaleButton.Text = "Skaliert";
            this.ScaleButton.CheckedChanged += new System.EventHandler(this.ScaleButton_CheckedChanged);
            // 
            // BasicButton
            // 
            this.BasicButton.Location = new System.Drawing.Point(368, 264);
            this.BasicButton.Name = "BasicButton";
            this.BasicButton.Size = new System.Drawing.Size(104, 24);
            this.BasicButton.TabIndex = 31;
            this.BasicButton.Text = "Gleichm‰ﬂig";
            this.BasicButton.CheckedChanged += new System.EventHandler(this.BasicButton_CheckedChanged);
            // 
            // SmallButton
            // 
            this.SmallButton.Location = new System.Drawing.Point(472, 240);
            this.SmallButton.Name = "SmallButton";
            this.SmallButton.Size = new System.Drawing.Size(112, 24);
            this.SmallButton.TabIndex = 32;
            this.SmallButton.Text = "Groﬂe Punkte";
            this.SmallButton.CheckedChanged += new System.EventHandler(this.SmallButton_CheckedChanged_1);
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(360, 400);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(232, 48);
            this.crossPanel.TabIndex = 33;
            // 
            // OverloadButton
            // 
            this.OverloadButton.BackColor = System.Drawing.Color.LightGray;
            this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OverloadButton.Location = new System.Drawing.Point(48, 208);
            this.OverloadButton.Name = "OverloadButton";
            this.OverloadButton.Size = new System.Drawing.Size(216, 32);
            this.OverloadButton.TabIndex = 34;
            this.OverloadButton.Text = "Beschriftungen";
            this.OverloadButton.UseVisualStyleBackColor = false;
            this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
            this.previewBox.Location = new System.Drawing.Point(8, 248);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(352, 344);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 35;
            // 
            // OutputFormMultiMatrix
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 614);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.OverloadButton);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.SmallButton);
            this.Controls.Add(this.BasicButton);
            this.Controls.Add(this.ScaleButton);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YRemove);
            this.Controls.Add(this.YAdd);
            this.Controls.Add(this.XRemove);
            this.Controls.Add(this.XAdd);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.XBox);
            this.Controls.Add(this.sizeControl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormMultiMatrix";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			mm.eval = eval;
			mm.Cross = cross.Cross;
			mm.width =  sizeControl.ChosenWidth;
			mm.height = sizeControl.ChosenHeight;

			
			if (single)
			{
				SaveDialog sd = new SaveDialog(mm);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		private void XAdd_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					XBox.Items.Add(q);
			}
			Preview(false);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					YBox.Items.Add(q);
			}
			Preview(false);
		}

		private void XRemove_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < XBox.SelectedItems.Count; i++)
			{
				XBox.Items.Remove(XBox.SelectedItems[i]);
			}
			Preview(false);
		}

		private void cpp_SelectionChanged()
		{
			Preview(false);
		}

		private void YRemove_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < YBox.SelectedItems.Count; i++)
			{
				YBox.Items.Remove(YBox.SelectedItems[i]);
			}
			Preview(false);
		}

		private void Preview(bool bigonly)
		{
			if (XBox.Items.Count > 0 && XBox.Items.Count == YBox.Items.Count)
			{
				mm.eval = eval;
				mm.Cross = cross.Cross;
				mm.width = previewBox.Width;
				mm.height = previewBox.Height - 20;
				mm.PersonList = cpp.SelectedPersons;
				mm.ComboList = cpp.SelectedCombos;
				if (ScaleButton.Checked) mm.Format = Output.FORMAT_SCALED;
				if (BasicButton.Checked) mm.Format = Output.FORMAT_BASIC;
				mm.Small = SmallButton.Checked;

				Question[] xq = new Question[XBox.Items.Count];
				Question[] yq = new Question[YBox.Items.Count];

				int i = 0;
				foreach (Question q in XBox.Items)
					xq[i++] = q;

				i = 0;
				foreach (Question q in YBox.Items)
					yq[i++] = q;

				mm.xq = xq;
				mm.yq = yq;

				if (!bigonly)
				{
					mm.Compute();

					previewBox.SmallPreview = mm.OutputImage;
				}

				mm.width = sizeControl.ChosenWidth;
				mm.height = sizeControl.ChosenHeight;

				mm.Compute();

				previewBox.BigPreview = mm.FullImage;
			}
		}

		private void ScaleButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ScaleButton.Checked)
			{
				BasicButton.Checked = false;
				Preview(false);
			}
		}

		private void BasicButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (BasicButton.Checked)
			{
				ScaleButton.Checked = false;
				Preview(false);
			}
		}

		private void SmallButton_CheckedChanged_1(object sender, System.EventArgs e)
		{
			Preview(false);
		}

		private void OverloadButton_Click(object sender, System.EventArgs e)
		{
			Question[] xq = new Question[XBox.Items.Count+YBox.Items.Count];

			int i = 0;
			foreach (Question q in XBox.Items)
				xq[i++] = q;

			foreach (Question q in YBox.Items)
				xq[i++] = q;

			DialogTextOverload dto = new DialogTextOverload(eval, xq);
			dto.ShowDialog();

			Preview(true);
		}

		private void sizeControl_ChosenSizeChanged()
		{
			Preview(true);
		}

		private void cross_CrossChanged()
		{
			mm.Cross = cross.cross;
		}

        private void sizeControl_Load(object sender, EventArgs e)
        {

        }
	}
}

